using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace SergeresISIS
{
    public partial class Child : Form
    {

        public Child()
        {
            InitializeComponent();
        }

        private void Child_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 3;
            //dataGridView1.RowCount = 10;
            dataGridView1.Columns[0].HeaderText = "Длина слова";
            dataGridView1.Columns[1].HeaderText = "Кол-во слов";
            dataGridView1.Columns[2].HeaderText = "Частота встречи, %";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "n2";
            if (Auth.Role == "Moder")
            {

            }
            else 
                if (Auth.Role == "User")
            {
                button12.Enabled = false;
                button13.Enabled = false;
                textBox1.Enabled = false;
                
            }
            //udbc class1 = new udbc();

            //string reservations = class1.DUDAdd();
            //string[] items = reservations.Split(new char[] { ';' });
            //foreach (string i in items)
            //    domainUpDown1.Items.Add(i);
        }

        string MyFName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            openFileDialog1.Title = "Выбирите файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = openFileDialog1.FileName;
                try
                {
                    richTextBox1.LoadFile(MyFName);
                }
                catch { richTextBox1.Text = File.ReadAllText(MyFName); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                //richTextBox1.SaveFile(MyFName);
                // Form2 aAuthor = new Form2();
                //aAuthor.ShowDialog();
                string message = "Невозможно сохранить пустой файл.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MyFName = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(MyFName);
                }
            }
        }

        public int GetCountWordsByLength(string text, int length)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n', ',', '?', '-', '.', ':' }; // разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // все слова
            return words.Where(x => x.Length == length).ToList().Count; // количество слов по условию 
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (richTextBox1.Text == "")
            {
                //richTextBox1.SaveFile(MyFName);
                // Form2 aAuthor = new Form2();
                //aAuthor.ShowDialog();
                string message = "Загрузите файл.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                button3.Enabled = false;
                for (int x = 0; x < trackBar1.Value; x++)
                {
                    dataGridView1.Rows.Add();
                }

                // string text = richTextBox1.Text;// "я веселный молочник\n кто сказал, что я один?";
                for (int x = 0, y = 1; x < trackBar1.Value; x++)
                {
                    dataGridView1.Rows[x].Cells[0].Value = y;
                    y++;
                }
                for (int x = 0, y = 1; y <= trackBar1.Value;)
                {
                    var count = GetCountWordsByLength(richTextBox1.Text, y);
                    dataGridView1.Rows[x].Cells[1].Value = count;
                    y++;
                    x++;
                    //count == 0;
                }

                int arrSize = 0;
                double textSize = 0;
                for (int x = 0; x < trackBar1.Value;)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[x].Cells[1].Value) != 0)
                    {
                        arrSize++;
                        textSize += Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value);
                        x++;
                    }
                    else
                    {
                        x++;
                    }
                }

                for (int x = 0; x < trackBar1.Value; x++)
                {
                    dataGridView1.Rows[x].Cells[2].Value = ((Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value) * 100) / textSize);
                    // y++;
                }


                int[] arrSourse = new int[arrSize];
                string[] yValues = new string[arrSize];
                for (int x = 0, y = 0; x < trackBar1.Value && y < arrSize;)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[x].Cells[1].Value) != 0)
                    {
                        arrSourse[y] = Convert.ToInt32(dataGridView1.Rows[x].Cells[1].Value);
                        yValues[y] = Convert.ToString(dataGridView1.Rows[x].Cells[0].Value);//+" - " + Convert.ToString(Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value))+"%";
                        x++;
                        y++;
                    }
                    else
                    {
                        x++;
                    }
                }
                
                //chart1.Series[0].Label = "#PERCENT{P}"; //Отображать значения Y в процентах
                //chart1.Legends["Legend1"].CellColumns.Add(new LegendCellColumn("Name", LegendCellColumnType.Text, "#LEGENDTEXT"));
                //chart1.Legends[Legend1] = "#VALX"; //В легенде отображать значения по X

                button1.Enabled = false;
                /*
                int[] arrNumbers = new int[10];
                for (int x=0; x<10;x++)
                {
                    arrNumbers[x] = Convert.ToInt32(dataGridView1.Rows[x].Cells[1].Value);
                }

                string[] xValues = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                chart1.Series[0].Points.DataBindXY(xValues, arrNumbers);
                //var count = GetCountWordsByLength(richTextBox1.Text, 3); // количество слов длинной в 3 символа
                //dataGridView1.Rows[0].Cells[1].Value = count;
                //textBox1.AppendText ( Convert.ToString(count));
                */
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            richTextBox1.Clear();
            dataGridView1.Rows.Clear();
            button3.Enabled = true;
            button5.Enabled = true;
            trackBar1.Value = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string fileName = @"D:\\data.xml";
            List<Profile> Stat = new List<Profile>();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow _row = dataGridView1.Rows[i];

                Profile p = new Profile();
                if (_row.Cells[0].Value != null)
                    p.LongOfWord = (int)_row.Cells[0].Value;

                if (_row.Cells[1].Value != null)
                    p.Count = (int)_row.Cells[1].Value;

                if (_row.Cells[2].Value != null)
                    p.Percent = ((double)_row.Cells[2].Value);
                Stat.Add(p);
            }
            Serializer.Save<List<Profile>>(Stat, "Statistic.xml");
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveINI = new SaveFileDialog();
            saveINI.Filter = "INI File |*.ini";
            if (saveINI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IniFiles ini = new IniFiles(saveINI.FileName);
                ini.Write("App", "Value", trackBar1.Value.ToString());
                ini.Write("App", "FileRoute", MyFName);
                ini.Write("App","FormWidth", Convert.ToString(this.Size.Width));
                ini.Write("App", "FormHeight", Convert.ToString(this.Size.Height));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog o1 = new OpenFileDialog();
            o1.Filter = "INI File |*.ini";
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IniFiles ini = new IniFiles(o1.FileName);
                string reini = ini.ReadINI("App", "Value");
                string fini = ini.ReadINI("App", "FileRoute");
                int i = int.Parse(reini);
                trackBar1.Value = i;
                //richTextBox1.LoadFile(fini);
                    using (StreamReader sr = new StreamReader(fini))
                    {
                    richTextBox1.Text = (sr.ReadToEnd());
                    }
                Width = Convert.ToInt32(ini.ReadINI("App", "FormWidth"));
                Height = Convert.ToInt32(ini.ReadINI("App", "FormHeight"));

            }
        }


        [Serializable]
        public class Profile
        {
            public int LongOfWord;
            public int Count;
            public double Percent;
        }

        class Serializer
        {

            public static T Load<T>(string _fileName)
            {
                /* Восстанавливаем из файла в файл. */

                TextReader _writer = null;

                try
                {
                    XmlSerializer _Serializer = new XmlSerializer(typeof(T));
                    _writer = new StreamReader(_fileName);

                    return (T)_Serializer.Deserialize(_writer);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return default(T);
                }
                finally
                {
                    if (_writer != null)
                        _writer.Close();
                }
            }

            public static bool Save<T>(T obj, string _file)
            {
                TextWriter _writer = null;
                try
                {
                    XmlSerializer _Serializer = new XmlSerializer(typeof(T));
                    _writer = new StreamWriter(_file);
                    _Serializer.Serialize(_writer, obj);
                    return true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    if (_writer != null)
                        _writer.Close();
                }

            }
        }

        static string openedFile = " "; 

        private void button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(domainUpDown1.Text) && !string.IsNullOrWhiteSpace(domainUpDown1.Text))
            {
                try
                {
                    udbc class1 = new udbc();
                    openedFile = domainUpDown1.Text;
                    string content = class1.OpenText(openedFile);
                    richTextBox1.Text = content;
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "WARNING, CRITICAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    richTextBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Выбирите текст!", "WARNING, CRITICAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int wSize = this.Size.Width;
            int hSize = this.Size.Height;
            int tVal = trackBar1.Value;
            string lText = openedFile;
            udbc class1 = new udbc();
            class1.IniAdd(wSize, hSize, tVal, lText);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            udbc class1 = new udbc();
            int wSizeL = class1.ReadWidth();
            int hSizeL = class1.ReadHeight();
            int tValL = class1.ReadLen();
            string lTextL = class1.ReadText();
            Width = wSizeL;
            Height = hSizeL;
            trackBar1.Value = tValL;
            string content = class1.OpenText(lTextL);
            richTextBox1.Text = content;
        }

        public void view()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64195/");
            HttpResponseMessage response = client.GetAsync("api/products").Result;
            var setting = response.Content.ReadAsAsync<IEnumerable<IniSet>>().Result;
            dataGridView2.DataSource = setting;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:64195/");
            //HttpResponseMessage response = client.GetAsync("api/products").Result;
            //var setting = response.Content.ReadAsAsync<IEnumerable<IniSet>>().Result;
            //dataGridView2.DataSource = setting;
            view();
        }

        private async void AddSetting()
        {
            IniSet s = new IniSet();
            s.Name = "track bar value";
            s.Value = Convert.ToString(trackBar1.Value);
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(s);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:64195/api/products", content);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AddSetting();
            System.Threading.Thread.Sleep(1000);
            view();
        }


        private async void DeleteProduct(int delid)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(String.Format("{0}/{1}", "http://localhost:64195/api/products", delid));
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteProduct(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("Настройка удалена");
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
