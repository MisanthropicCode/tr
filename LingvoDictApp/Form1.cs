using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Linguistics.Dictionary;

namespace LingvoDictApp
{
    public partial class Form1 : Form
    {
        IDictionary dictionary = new LingvoPdaDictionary();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WordTranslation translation = dictionary.GetTranslation(textBox2.Text, TranslationDirection.EnRu);

            textBox1.Text = translation.Translation;
        }
    }
}
