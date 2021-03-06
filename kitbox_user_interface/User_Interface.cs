﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security.Certificates;
using projectCS;
using projectCS.Tools_class;

namespace kitbox_user_interface_V1
{
    public partial class User_Interface : Form
    {
        public User_Interface()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            string MyConString = "SERVER=localhost;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=K8tB0x_sql; old guids = true";
            //string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panel LR\"");
            conn.Close();
            conn.Open();
            List<string> BracketsColorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"AngleBracket\"");
            conn.Close();
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> ColorDoorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Door\"");
            conn.Close();
            conn.Open();
            List<string> ColorPannelBaList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> HeightBracketsList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"AngleBracket\"");
            conn.Close();
            
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            //TODO : get variable globale max_lockers puis boucle pour remplir combobox3
            comboBox2.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox3.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox4.Items.AddRange(BracketsColorList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(ColorDoorList.Cast<object>().ToArray());
            comboBox6.Items.Add("none");
            comboBox7.Items.AddRange(ColorPannelBaList.Cast<object>().ToArray());
            comboBox9.Items.AddRange(new object[] { "yes", "no" });

            int maxHeight = 0;
            foreach (string heightB in HeightBracketsList)
            {
                int heightBP = Int32.Parse(heightB);
                if (heightBP > maxHeight)
                {
                    maxHeight = heightBP;
                }
            }
            textBox12.Text = "0";
            textBox14.Text = maxHeight.ToString();
            textBox16.Text = "0";

            dataGridView1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            bool choice_fill = false;

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                ComponentColor color1 = EnumParse.parseColorStrToEnum(comboBox4.SelectedItem.ToString());
                int numberOfLockers = Int32.Parse(comboBox1.SelectedItem.ToString());
                int width = Int32.Parse(comboBox2.SelectedItem.ToString());
                int depth = Int32.Parse(comboBox3.SelectedItem.ToString());

                ShoppingCart.addCupboardUserChoices(width, depth, numberOfLockers, color1);
                choice_fill = true;
            }
            else
            {
                MessageBox.Show("Fill every choices");
                button1.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }
            if (choice_fill)
            {
                int widthChosen = ShoppingCart.widthChosen;
                if (widthChosen < 62)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Add("none");
                }
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                comboBox9.Enabled = true;
                button2.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;

            //TODO check if cups are checked
            // check that the object fields are filled
            if (comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && comboBox7.SelectedItem != null)
            {
                int height = Int32.Parse(comboBox5.SelectedItem.ToString());
                string doorsColor = comboBox6.SelectedItem.ToString();
                string panelColor = comboBox7.SelectedItem.ToString();
                int doorWidth = 0;
                bool doorCup = false;
                if (doorsColor!="none")
                {
                    if (width >= 62)
                    {
                        if (width == 62)
                        {
                            doorWidth = 31;
                        }
                        else
                        {
                            doorWidth = width / 2 + 2;
                        }
                    }
                    if(doorsColor != "Glass" && comboBox9.SelectedItem != null)
                    {
                        if(comboBox9.SelectedItem.ToString() == "yes")
                        {
                            doorCup = true;
                        }
                    }
                }

                Locker locker = new Locker();
               
                CatalogueDB cb = new CatalogueDB();
                
                Cleat cleat1 = (Cleat)cb.createComponents(height, 0, 0, "Cleat");
                if (doorsColor != "none")
                {
                    Door door1 = (Door)cb.createComponents(height, doorWidth, 0, EnumParse.parseColorStrToEnum(doorsColor), doorCup, "Door");
                    locker.addComponent(new List<CatalogueComponents>() { door1, door1 });
                }
                Panels panelsHL = (Panels)cb.createComponents(0, width, depth, EnumParse.parseColorStrToEnum(panelColor), PanelsType.HL, "Panel");
                Panels panelsLR = (Panels)cb.createComponents(height, 0, depth, EnumParse.parseColorStrToEnum(panelColor), PanelsType.LR, "Panel");
                Panels panelsB = (Panels)cb.createComponents(height, width, 0, EnumParse.parseColorStrToEnum(panelColor), PanelsType.B, "Panel");

                CrossBar crossBarF = (CrossBar)cb.createComponents(0, width, 0, CrossBarType.F, "CrossBar");
                CrossBar crossBarB = (CrossBar)cb.createComponents(0, width, 0, CrossBarType.B, "CrossBar");
                CrossBar crossBarLR = (CrossBar)cb.createComponents(0, 0, depth, CrossBarType.LR, "CrossBar");

                

                // numéro du casier sur lequel on travail
                int currentbox = locker.ID;


                locker.panelColor = EnumParse.parseColorStrToEnum(panelColor);
                locker.height = height;
                locker.depth = depth;
                locker.width = width;
                if(doorsColor !="none")
                    locker.doorsColor = EnumParse.parseColorStrToEnum(doorsColor);



                locker.addComponent(new List<CatalogueComponents>() { cleat1, cleat1, cleat1, cleat1,
                                                                        panelsHL, panelsHL, panelsLR,  panelsLR, panelsB,
                                                                        crossBarF, crossBarF, crossBarB, crossBarB,
                                                                        crossBarLR, crossBarLR, crossBarLR, crossBarLR });
                
                ShoppingCart.addCupboardComponent(locker);

                //premier essai de calcul de prix
                double prixTotal = locker.price;
                

                // met dans le order preview
                dataGridView1.Rows.Add(currentbox, height, doorsColor, doorCup, panelColor,prixTotal.ToString());

                //TODO remplacer total height par la somme des hauteurs
                int totalHeight = Int32.Parse(textBox12.Text);
                totalHeight += height + 4;
                textBox12.Text = totalHeight.ToString();
                if (currentbox == numberOfLocker)
                {
                    button2.Enabled = false;
                }
                else
                {
                    currentbox++;
                    textBox8.Text = currentbox.ToString();
                }

                //TODO remplacer cupboardPrice par var globale
                double cupboardPrice = Double.Parse(textBox16.Text);
                textBox16.Text = (cupboardPrice + prixTotal).ToString();

                /*
                 * height choices gestion
                 */
                int maxHeight = Int32.Parse(textBox14.Text);
                List<string> choiceRemove = new List<string>();
                foreach (string heightChoice in comboBox5.Items)
                {
                    int boxHeight = Int32.Parse(heightChoice);
                    if (maxHeight - boxHeight - 4 < totalHeight)
                    {
                        choiceRemove.Add(heightChoice);
                    }

                }
                foreach (string heightChoice in choiceRemove)
                {
                    comboBox5.Items.Remove(heightChoice);
                }
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
            if (!button2.Enabled)
            {
                button3.Visible = true;
                button3.Enabled = true;
                button5.Visible = true;
                button5.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button2.Enabled = false;
            button4.Visible = true;
            button4.Enabled = true;

            dataGridView1.Enabled = true;

            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panel B\"");
            conn.Close();
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //assign currentLocker
            if (ShoppingCart.currentLocker == 0)
                ShoppingCart.currentLocker = ShoppingCart.cupboardComponentsList.Count;

            //get former and cupboard values
            int width = ShoppingCart.getLockerByID(ShoppingCart.currentLocker).width;
            int formerHeight = Int32.Parse(dataGridView1[1, ShoppingCart.currentLocker - 1].Value.ToString());
            int totalHeight = Int32.Parse(textBox12.Text);
            int maxHeight = Int32.Parse(textBox14.Text);
            double formerPrice = Double.Parse(dataGridView1[5, ShoppingCart.currentLocker - 1].Value.ToString());
            double cupboardPrice = Double.Parse(textBox16.Text);

            //verify every box filled
            if (comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && comboBox7.SelectedItem != null)
            {
                //get new values
                int height = Int32.Parse(comboBox5.SelectedItem.ToString());
                string doorsColor = comboBox6.SelectedItem.ToString();
                string panelColor = comboBox7.SelectedItem.ToString();
                bool doorCup = false;

                //assign doorcup
                if(doorsColor!="Glass" && doorsColor !="none")
                {
                    //TODO check if combobox9 filled
                    if (comboBox9.SelectedItem.ToString() == "yes")
                        doorCup = true;
                }

                //compute totalHeight and verify max height not reached
                if (totalHeight - formerHeight - 4 + height < maxHeight)
                {
                    //save changes
                    totalHeight -= formerHeight;
                    totalHeight += height;
                    textBox12.Text = totalHeight.ToString();
                    
                    //save locker new variables
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).height = height;
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).panelColor = EnumParse.parseColorStrToEnum(panelColor);
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).setCupOfDoor(doorCup);
                    if (doorsColor != "none")
                        ShoppingCart.getLockerByID(ShoppingCart.currentLocker).doorsColor = EnumParse.parseColorStrToEnum(doorsColor);
                    
                    /*
                     * if doorsColor were none then add new doors
                     * if doorsColor were not none then new doors not added (locker definition)
                     */
                    CatalogueDB catalogueDB = new CatalogueDB();
                    int doorWidth = 0;
                    if (width >= 62)
                    {
                        if (width == 62)
                        {
                            doorWidth = 31;
                        }
                        else
                        {
                            doorWidth = width / 2 + 2;
                        }
                    }
                    Door door1 = (Door)catalogueDB.createComponents(height, doorWidth, 0, EnumParse.parseColorStrToEnum(doorsColor), doorCup, "Door");
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).addComponent(new List<CatalogueComponents>() { door1, door1 });

                    
                    //compute newPrice
                    foreach(CatalogueComponents compo in ShoppingCart.getLockerByID(ShoppingCart.currentLocker).componentsList)
                    {
                        compo.price = catalogueDB.newPrice(height, doorsColor, panelColor, compo);
                    }
                    double newPrice = ShoppingCart.getLockerByID(ShoppingCart.currentLocker).price;
                    
                    //display new informations
                    dataGridView1.Rows[ShoppingCart.currentLocker - 1].SetValues(ShoppingCart.currentLocker, height, doorsColor,doorCup, panelColor,newPrice);

                    //TODO mettre yes no plutôt que true false dans l'afficheur

                    //display total lockers price
                    cupboardPrice -= formerPrice;
                    cupboardPrice += newPrice;
                    textBox16.Text = cupboardPrice.ToString();
                    
                }
                else
                    MessageBox.Show("Maximal height reached");
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_purchase validation = new Form_purchase();
            validation.Show();
            validation.FormClosed += new FormClosedEventHandler(Form_purchase_FormClosed);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShoppingCart.currentLocker = dataGridView1.CurrentCell.RowIndex + 1;
            textBox8.Text = ShoppingCart.currentLocker.ToString();
        }

        void Form_purchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.ToString() == "none" || comboBox6.SelectedItem.ToString() == "Glass")
            {
                comboBox9.Enabled = false;
            }
            else
                comboBox9.Enabled = true;
        }

    }

}
