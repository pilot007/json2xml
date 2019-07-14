using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Xml;

namespace Json_Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Item
        {
            public string id { get; set; }
            public string urun_kod { get; set; }
            public string urun_ad { get; set; }
            public string perakende_kdv { get; set; }
            public string toptan_kdv { get; set; }
            public string birim_1_ad { get; set; }
            public string birim_2_ad { get; set; }
            public string birim_2_katsayi { get; set; }
            public string birim_3_ad { get; set; }
            public string birim_3_katsayi { get; set; }
            public string birim_4_ad { get; set; }
            public string birim_4_katsayi { get; set; }
            public string kategori_kod { get; set; }
            public string kategori_ad { get; set; }
            public string anagrup_kod { get; set; }
            public string anagrup_ad { get; set; }
            public string altgrup_kod { get; set; }
            public string altgrup_ad { get; set; }
            public string marka_kod { get; set; }
            public string marka_ad { get; set; }
            public string uretici_ad { get; set; }
            public string barkod_1 { get; set; }
            public string barkod_2 { get; set; }
            public string barkod_3 { get; set; }
            public string barkod_4 { get; set; }
            public string tedarikci_kod { get; set; }
            public string fiyat { get; set; }

            public string doviz { get; set; }
            public string kalite_kontrol_kod { get; set; }
            public string kalite_kontrol_ad { get; set; }
            public string sektor_kod { get; set; }
            public string sektor_ad { get; set; }
            public string ambalaj_kod { get; set; }
            public string ambalaj_ad { get; set; }
            public string stok_aciklama { get; set; }
            public string stok_resim_url { get; set; }
            public string stok_resim_url2 { get; set; }
            public string stok_resim_url3 { get; set; }
            public string net_fiyat { get; set; }
            public string iskonto { get; set; }
            public string alinan_siparis_birim { get; set; }
            public string birim_1_katsayi { get; set; }
            public string resim { get; set; }
            public string resim1 { get; set; }
            public string resim2 { get; set; }
            public string resim3 { get; set; }
            public string yazar_adi { get; set; }
            public string yayinevi { get; set; }
            public string ana_grup { get; set; }
            public string alt_grup { get; set; }
            public string diger_isim { get; set; }
            public string stok_miktar { get; set; }
            public string stok_miktar_toplam { get; set; }
        }
        class CustomerOrderSummary
        {
            public string result { get; set; }
            public List<Item> data { get; set; }
        }


        public void Button1_Click(object sender, EventArgs e)
        {
           string res= Jsoddownload();
            xmlconvert(res);
        }

        public string Jsoddownload()
        {
            RESTClient rClient = new RESTClient();

            DateTime foo = DateTime.UtcNow.AddDays(-15);
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

            rClient.endPoint = "http://panel.natyazilim.com/ws/integration/get_price/36C9F24258376805D1BCC327DE06EF34/QIR44OZY9K/json/"+ unixTime;

            rClient.httpMethod = httpVerb.GET;

            string strJSON = string.Empty;

            strJSON = rClient.makeRequest();

            return strJSON;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            filepath();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            savefilepath();
        }

        public  void xmlconvert(String st)
        {
            //String st = File.ReadAllText(textBox1.Text, Encoding.Default);
            var example1Model = new JavaScriptSerializer().Deserialize<CustomerOrderSummary>(st);

            // Xml başlangıç 
            XmlTextWriter yaz = new XmlTextWriter(textBox2.Text, System.Text.UTF8Encoding.UTF8);
            //Daha önce bu isimle oluşturulan bir XML dosyası var ise, eski dosya silinir.
            yaz.Formatting = Formatting.Indented;

            // Dosya yapısını hiyerarşik olarak oluşturarak okunabilirliği arttırır.
            try
            {
                yaz.WriteStartDocument(); //Xml dökümanına ait declaration satırını oluşturur. Kısaca yazmaya başlar.
                yaz.WriteStartElement("root");

                //okul ve ogretmen etiketleri oluşturuldu.
                for (int i = 0; i < example1Model.data.Count; i++)
                {
                    yaz.WriteStartElement("item");

                    yaz.WriteElementString("id", example1Model.data[i].id);
                    yaz.WriteElementString("urun_kod", example1Model.data[i].urun_kod);
                    yaz.WriteElementString("urun_ad", example1Model.data[i].urun_ad);
                    yaz.WriteElementString("perakende_kdv", example1Model.data[i].perakende_kdv);
                    yaz.WriteElementString("toptan_kdv", example1Model.data[i].toptan_kdv);
                    yaz.WriteElementString("birim_1_ad", example1Model.data[i].birim_1_ad);
                    yaz.WriteElementString("birim_2_ad", example1Model.data[i].birim_2_ad);
                    yaz.WriteElementString("birim_2_katsayi", example1Model.data[i].birim_2_katsayi);
                    yaz.WriteElementString("birim_3_ad", example1Model.data[i].birim_3_ad);
                    yaz.WriteElementString("birim_3_katsayi", example1Model.data[i].birim_3_katsayi);
                    yaz.WriteElementString("birim_4_ad", example1Model.data[i].birim_4_ad);
                    yaz.WriteElementString("birim_4_katsayi", example1Model.data[i].birim_4_katsayi);
                    yaz.WriteElementString("kategori_kod", example1Model.data[i].kategori_kod);
                    yaz.WriteElementString("kategori_ad", example1Model.data[i].kategori_ad);
                    yaz.WriteElementString("anagrup_kod", example1Model.data[i].anagrup_kod);
                    yaz.WriteElementString("anagrup_ad", example1Model.data[i].anagrup_ad);
                    yaz.WriteElementString("altgrup_kod", example1Model.data[i].altgrup_kod);
                    yaz.WriteElementString("altgrup_ad", example1Model.data[i].altgrup_ad);
                    yaz.WriteElementString("marka_kod", example1Model.data[i].marka_kod);
                    yaz.WriteElementString("marka_ad", example1Model.data[i].marka_ad);
                    yaz.WriteElementString("uretici_ad", example1Model.data[i].uretici_ad);
                    yaz.WriteElementString("barkod_1", example1Model.data[i].barkod_1);
                    yaz.WriteElementString("barkod_2", example1Model.data[i].barkod_2);
                    yaz.WriteElementString("barkod_3", example1Model.data[i].barkod_3);
                    yaz.WriteElementString("barkod_4", example1Model.data[i].barkod_4);
                    yaz.WriteElementString("tedarikci_kod", example1Model.data[i].tedarikci_kod);
                    yaz.WriteElementString("fiyat", example1Model.data[i].fiyat);
                    yaz.WriteElementString("doviz", example1Model.data[i].doviz);
                    yaz.WriteElementString("kalite_kontrol_kod", example1Model.data[i].kalite_kontrol_kod);
                    yaz.WriteElementString("kalite_kontrol_ad", example1Model.data[i].kalite_kontrol_ad);
                    yaz.WriteElementString("sektor_kod", example1Model.data[i].sektor_kod);
                    yaz.WriteElementString("sektor_ad", example1Model.data[i].sektor_ad);
                    yaz.WriteElementString("ambalaj_kod", example1Model.data[i].ambalaj_kod);
                    yaz.WriteElementString("ambalaj_ad", example1Model.data[i].ambalaj_ad);
                    yaz.WriteElementString("stok_aciklama", example1Model.data[i].stok_aciklama);
                    yaz.WriteElementString("stok_resim_url", example1Model.data[i].stok_resim_url);
                    yaz.WriteElementString("stok_resim_url2", example1Model.data[i].stok_resim_url2);
                    yaz.WriteElementString("stok_resim_url3", example1Model.data[i].stok_resim_url3);
                    yaz.WriteElementString("net_fiyat", example1Model.data[i].net_fiyat);
                    yaz.WriteElementString("iskonto", example1Model.data[i].iskonto);
                    yaz.WriteElementString("alinan_siparis_birim", example1Model.data[i].alinan_siparis_birim);
                    yaz.WriteElementString("birim_1_katsayi", example1Model.data[i].birim_1_katsayi);
                    yaz.WriteElementString("resim", example1Model.data[i].resim);
                    yaz.WriteElementString("resim1", example1Model.data[i].resim1);
                    yaz.WriteElementString("resim2", example1Model.data[i].resim2);
                    yaz.WriteElementString("resim3", example1Model.data[i].resim3);
                    yaz.WriteElementString("yazar_adi", example1Model.data[i].yazar_adi);
                    yaz.WriteElementString("yayinevi", example1Model.data[i].yayinevi);
                    yaz.WriteElementString("ana_grup", example1Model.data[i].ana_grup);
                    yaz.WriteElementString("alt_grup", example1Model.data[i].alt_grup);
                    yaz.WriteElementString("diger_isim", example1Model.data[i].diger_isim);
                    yaz.WriteElementString("stok_miktar", example1Model.data[i].stok_miktar);
                    yaz.WriteElementString("stok_miktar_toplam", example1Model.data[i].stok_miktar_toplam);


                    yaz.WriteEndElement();
                }

                //İçerik isim-değer çiftleri şeklinde ogretmen etiketinin içerisine element türünde eklendi.

                yaz.WriteEndElement();
                //okul ve ogretmen etiketleri sonlandırıldı.
                yaz.Close();
                //XML akışı sonlandırıldı.
                MessageBox.Show("XML dosyası oluşturuldu ve veriler eklendi.", "Bilgilendirme Penceresi");
                Console.WriteLine("XML dosyası oluşturuldu ve veriler eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu:" + ex.Message, "Bilgilendirme Penceresi");
                Console.WriteLine("Hata Oluştu:" + ex.Message);
            }
        }
        public void filepath()
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Title = "JSON Data";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            textBox1.Text = DosyaYolu;
        }
        public void savefilepath()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = true;
            save.CreatePrompt = true;
            save.Filter = "*|.xml";
            save.ShowDialog();
            textBox2.Text = save.FileName;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
