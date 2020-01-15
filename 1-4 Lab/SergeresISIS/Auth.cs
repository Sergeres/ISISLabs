using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SergeresISIS
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        public static bool ID0;
        public static string Role;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                udbc class1 = new udbc();

                ID0 = class1.Auth(textBox1.Text, textBox2.Text);
                Role = class1.Auth2(textBox1.Text, textBox2.Text);
                if (ID0 == true)
                {
                    Form MDI = new MDI();
                    MDI.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ошибка входа!", "WARNING, CRITICAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Fill all fields", "WARNING, CRITICAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
