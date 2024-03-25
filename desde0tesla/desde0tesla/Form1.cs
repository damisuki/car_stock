using System;
using System.Windows.Forms;

namespace desde0tesla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelSubMenuTeslas.Visible = false;
            panelSubMenuSpacex.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelSubMenuTeslas.Visible == true)
                panelSubMenuTeslas.Visible = false;
            if (panelSubMenuSpacex.Visible == true)
                panelSubMenuSpacex.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void buttonteslas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuTeslas);
        }

        private void buttonXSubMenu_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());

            ///..
            ////aca rellenar
            ///
            hideSubMenu();
        }

        private void buttonSSubMenu_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());

            ///..
            ////aca rellenar
            ///
            hideSubMenu();
        }

        private void buttonCTSubMenu_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());

            ///..
            ////aca rellenar
            ///
            hideSubMenu();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuSpacex);
        }

        private void buttonStarShip_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());

            ///..
            ////aca rellenar
            ///
            hideSubMenu();
        }

        private void buttonFalcon9_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            ///..
            ////aca rellenar
            ///
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}