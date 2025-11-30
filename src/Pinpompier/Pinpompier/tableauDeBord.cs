using Pinpon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Pinpompier
{
    internal class tableauDeBord
    {
        DataTable tabMission = MesDatas.DsGlobal.Tables["mission"];
        DataTable tabCaserne = MesDatas.DsGlobal.Tables["caserne"];
        DataTable tabSinistre = MesDatas.DsGlobal.Tables["sinistre"];

        private SQLiteConnection cx;

        public void genererTableauDeBord(Panel cible, bool seulementEnCours = false)
        {
            cible.Controls.Clear();
            cible.BackColor = Color.DarkRed;

            CheckBox chkEnCours = new CheckBox
            {
                Text = "En cours",
                ForeColor = Color.White,
                Location = new Point(30, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                Checked = seulementEnCours
            };

            chkEnCours.CheckedChanged += (s, e) =>
            {
                genererTableauDeBord(cible, chkEnCours.Checked);
            };

            cible.Controls.Add(chkEnCours);

            FlowLayoutPanel flpMissions = new FlowLayoutPanel
            {
                Location = new Point(0, 100),
                Size = new Size(1070, 642),
                AutoScroll = true,
                WrapContents = false,
                BackColor = Color.DarkRed,
                FlowDirection = FlowDirection.TopDown
            };

            cible.Controls.Add(flpMissions);

            DataTable tabMission = MesDatas.DsGlobal.Tables["Mission"];
            DataTable tabCaserne = MesDatas.DsGlobal.Tables["Caserne"];
            DataTable tabSinistre = MesDatas.DsGlobal.Tables["NatureSinistre"];

            for (int i = tabMission.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = tabMission.Rows[i];

             
                if (seulementEnCours)
                {
                    if (row["terminee"].ToString() == "1")
                    {
                        continue; 
                    }
                }

                int id = Convert.ToInt32(row["id"]);
                string dateDepart = row["dateHeureDepart"].ToString();
                string motifAppel = row["motifAppel"].ToString();

                int idCaserne = Convert.ToInt32(row["idCaserne"]);
                int idSinistre = Convert.ToInt32(row["idNatureSinistre"]);

                // Lookup caserne
                string nomCaserne = "Caserne inconnue";
                DataRow[] casernes = tabCaserne.Select($"id = {idCaserne}");
                if (casernes.Length > 0)
                {
                    nomCaserne = casernes[0]["nom"].ToString();
                }

                // Lookup sinistre
                string libelleSinistre = "Type inconnu";
                DataRow[] sinistres = tabSinistre.Select($"id = {idSinistre}");
                if (sinistres.Length > 0)
                {
                    libelleSinistre = sinistres[0]["libelle"].ToString();
                }

                Panel card = new Panel
                {
                    Size = new Size(1000, 90),
                    BackColor = Color.LightCoral,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15)
                };

                PictureBox pic = new PictureBox
                {
                    Size = new Size(60, 60),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                card.Controls.Add(pic);

                Label lblInfos = new Label
                {
                    Text = $"Id mission : {id}                    Départ : {dateDepart}                    Caserne : {nomCaserne}",
                    Location = new Point(80, 5),
                    Size = new Size(700, 20)
                };
                card.Controls.Add(lblInfos);

                Label lblType = new Label
                {
                    Text = libelleSinistre,
                    Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(80, 35),
                    Size = new Size(400, 20)
                };
                card.Controls.Add(lblType);

                Label lblCommentaire = new Label
                {
                    Text = "--> " + motifAppel,
                    Location = new Point(80, 60),
                    Size = new Size(600, 20),
                    ForeColor = Color.DarkSlateGray
                };
                card.Controls.Add(lblCommentaire);

                Button btnCloturer = new Button
                {
                    Text = "Clôturer",
                    ForeColor = Color.White,
                    Size = new Size(80, 30),
                    Location = new Point(870, 10),
                    Tag = id
                };
                card.Controls.Add(btnCloturer);

                Button btnPDF = new Button
                {
                    Text = "PDF",
                    ForeColor = Color.White,
                    Size = new Size(80, 30),
                    Location = new Point(870, 50),
                    Tag = id
                };
                card.Controls.Add(btnPDF);
                btnPDF.Click += btnPDF_Click;

                PictureBox icone1 = new PictureBox
                {
                    Size = new Size(30, 30),
                    Location = new Point(930, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                card.Controls.Add(icone1);

                PictureBox icone2 = new PictureBox
                {
                    Size = new Size(30, 30),
                    Location = new Point(930, 50),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                card.Controls.Add(icone2);

                flpMissions.Controls.Add(card);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Connexion.FermerConnexion();
            cx = Connexion.Connec;
            Button btn = (Button)sender;
            int idMission = Convert.ToInt32(btn.Tag);

            DataRow[] missions = MesDatas.DsGlobal.Tables["Mission"].Select($"id = {idMission}");
            if (missions.Length == 0)
            {
                MessageBox.Show("Mission introuvable !");
                return;
            }

            DataRow mission = missions[0];

            Document doc = new Document(PageSize.A4);
            string chemin = "RapportMission" + idMission + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(chemin, FileMode.Create));

            doc.Open();

            BaseFont basefont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font titreFont = new iTextSharp.text.Font(basefont, 25, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE);
            iTextSharp.text.Font grasFont = new iTextSharp.text.Font(basefont, 15, iTextSharp.text.Font.BOLD);

            Paragraph titre = new Paragraph(new Phrase("Rapport de la mission n°" + idMission, titreFont));
            titre.Alignment = Element.ALIGN_CENTER;
            doc.Add(titre);
            doc.Add(new Paragraph("\n\n"));

            DateTime dateDebut = Convert.ToDateTime(mission["dateHeureDepart"]);
            doc.Add(new Paragraph("Déclenchée le : " + dateDebut.ToString("dd/MM/yyyy") + " à " + dateDebut.ToString("HH:mm")));

            if (Convert.ToInt32(mission["terminee"]) == 1)
            {
                DateTime dateFin = Convert.ToDateTime(mission["dateHeureRetour"]);
                doc.Add(new Paragraph("Retour le : " + dateFin.ToString("dd/MM/yyyy") + " à " + dateFin.ToString("HH:mm")));
            }

            doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------"));
            doc.Add(new Paragraph("\n\n"));

            string sinistre = "";
            foreach (DataRow row2 in MesDatas.DsGlobal.Tables["NatureSinistre"].Rows)
            {
                if (Convert.ToInt32(row2["id"]) == Convert.ToInt32(mission["idNatureSinistre"]))
                {
                    sinistre = row2["libelle"].ToString();
                }
            }

            doc.Add(new Paragraph(new Phrase("Type de sinistre : " + sinistre, titreFont)));
            doc.Add(new Paragraph(new Phrase("Motif : " + mission["motifAppel"], grasFont)));
            doc.Add(new Paragraph(new Phrase("Adresse : " + mission["adresse"] + " " + mission["cp"] + " " + mission["ville"], grasFont)));
            doc.Add(new Paragraph(new Phrase("Compte-rendu : " + mission["CompteRendu"], grasFont)));

            doc.Add(new Paragraph("--------------------------------------------------------------------------------------------------------------------------"));
            doc.Add(new Paragraph("\n\n"));

            // Engins
            doc.Add(new Paragraph(new Phrase("Engins affectés :", titreFont)));
            doc.Add(new Paragraph("\n"));

            string requete = "SELECT * FROM PartirAvec WHERE idMission = " + idMission;

            SQLiteCommand cmd = new SQLiteCommand(requete, cx);
            SQLiteDataReader row = cmd.ExecuteReader();

            while (row.Read())
            {
                string codeTypeEngin = row["codeTypeEngin"].ToString();
                string requete1 = "SELECT nom FROM TypeEngin WHERE code = '" + codeTypeEngin + "'";
                SQLiteCommand cmd1 = new SQLiteCommand(requete1, cx);
                string r1 = cmd1.ExecuteScalar()?.ToString() ?? "Type inconnu";

                string reparation = row["reparationsEventuelles"]?.ToString();
                if (string.IsNullOrEmpty(reparation))
                    reparation = "pas de réparations prévues";

                doc.Add(new Paragraph("--> : " + r1 + " " + row["idCaserne"] + "-" + codeTypeEngin + "-" + row["numeroEngin"] + " (" + reparation + ")"));
                doc.Add(new Paragraph("\n"));
            }
            row.Close();

            doc.Add(new Paragraph("\n"));

            // Pompiers
            doc.Add(new Paragraph(new Phrase("Pompiers affectés :", titreFont)));
            doc.Add(new Paragraph("\n"));

            string requete3 = "SELECT * FROM Mobiliser WHERE idMission = " + idMission;
            SQLiteCommand cmd3 = new SQLiteCommand(requete3, cx);
            SQLiteDataReader row3 = cmd3.ExecuteReader();

            while (row3.Read())
            {
                string requete4 = "SELECT g.libelle, p.nom, p.prenom FROM Grade g, Pompier p WHERE p.codeGrade = g.code AND p.matricule = " + row3["matriculePompier"];
                string requete5 = "SELECT libelle FROM Habilitation WHERE id = " + row3["idHabilitation"];

                SQLiteCommand cmd1 = new SQLiteCommand(requete4, cx);
                SQLiteDataReader r1 = cmd1.ExecuteReader();
                SQLiteCommand cmd2 = new SQLiteCommand(requete5, cx);
                string r2 = cmd2.ExecuteScalar()?.ToString() ?? "Non renseignée";

                if (r1.Read())
                {
                    doc.Add(new Paragraph("--> : " + r1["libelle"] + " " + r1["nom"] + " " + r1["prenom"] + " (" + r2 + ")"));
                    doc.Add(new Paragraph("\n"));
                }
                r1.Close();
            }
            row3.Close();

            doc.Close();

            Process.Start(new ProcessStartInfo(chemin) { UseShellExecute = true });
            Connexion.FermerConnexion();
        }


    }
}
