using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XML_Project
{
    public partial class Form1 : Form
    {
        XmlDocument docs = new XmlDocument();
        private XmlNode students;
        string path_dir = "Xml_file.xml";
        public Form1()
        {
            InitializeComponent();
            docs.Load(path_dir);
        }

        private void button1_Click(object sender, EventArgs e) //Insert
        {
            students = docs.GetElementsByTagName("Students").Item(0);
            XmlElement student = docs.CreateElement("Student");
            XmlElement Name = docs.CreateElement("Name");
            Name.InnerText = textBox1.Text;
            student.AppendChild(Name);
            XmlElement Add = docs.CreateElement("Address");
            Add.InnerText = textBox2.Text;
            student.AppendChild(Add);
            XmlElement Phone = docs.CreateElement("Phone");
            Phone.InnerText = textBox3.Text;
            student.AppendChild(Phone);
            students.AppendChild(student);
            docs.Save(path_dir);
            //MessageBox.Show(docs.DocumentElement.OuterXml);
            MessageBox.Show("Inserted Done");
            
        }

        private void button3_Click(object sender, EventArgs e) //Delete
        {
            string path = "/Students/Student[Name = '" + textBox1.Text + "']";
            XmlNode currNode = docs.SelectSingleNode(path);
            currNode.OwnerDocument.DocumentElement.RemoveChild(currNode);
            docs.Save(path_dir);
            MessageBox.Show("Deleted");

        }

        private void button5_Click(object sender, EventArgs e) //Next
        {
            string path = "/Students/Student[Name = '" + textBox1.Text + "']";
            XmlNode currNode = docs.SelectSingleNode(path);
            XmlNode next = currNode.NextSibling;
            textBox1.Text = next.ChildNodes[0].InnerText;
            textBox2.Text = next.ChildNodes[1].InnerText;
            textBox3.Text = next.ChildNodes[2].InnerText;
            //MessageBox.Show(next.InnerXml);
           
        }

        private void button6_Click(object sender, EventArgs e) //prev
        {
            string path = "/Students/Student[Name = '" + textBox1.Text + "']";
            XmlNode currNode = docs.SelectSingleNode(path);
            XmlNode prev = currNode.PreviousSibling;
            textBox1.Text = prev.ChildNodes[0].InnerText;
            textBox2.Text = prev.ChildNodes[1].InnerText;
            textBox3.Text = prev.ChildNodes[2].InnerText;
            //MessageBox.Show(prev.InnerXml);

        }

        private void button4_Click(object sender, EventArgs e) //Search
        {
            string path = "/Students/Student[Name = '" + textBox1.Text + "']";
            XmlNode currNode = docs.SelectSingleNode(path);
            //MessageBox.Show(currNode.InnerXml);
            textBox1.Text = currNode.ChildNodes[0].InnerText;
            textBox2.Text = currNode.ChildNodes[1].InnerText;
            textBox3.Text = currNode.ChildNodes[2].InnerText;

        }

        private void button2_Click(object sender, EventArgs e) //update
        {
            string path = "/Students/Student[Name = '" + textBox1.Text + "']";
            XmlNode currNode = docs.SelectSingleNode(path);
            currNode["Address"].InnerText = textBox2.Text;
            currNode["Phone"].InnerText = textBox3.Text;
            docs.Save(path_dir);
            MessageBox.Show("updated");

        }
    }
}
