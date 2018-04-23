using DevExpress.XtraTreeMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RangeColorizerSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            CreateTreeMapDataAdapter();
            CreateTreeMapColorizer();
        }

        void CreateTreeMapDataAdapter() {
            TreeMapHierarchicalDataAdapter dataAdapter = new TreeMapHierarchicalDataAdapter();
            dataAdapter.DataSource = CreateStatistics();

            // Fill the Mappings collection using mappings specifying 
            // how to convert data objects to tree map items.
            dataAdapter.Mappings.Add(new TreeMapHierarchicalDataMapping {
                Type = typeof(CountryStatistics),
                LabelDataMember = "Name",
                ChildrenDataMember = "EnergyStatistics"
            });
            dataAdapter.Mappings.Add(new TreeMapHierarchicalDataMapping {
                Type = typeof(EnergyInfo),
                LabelDataMember = "Type",
                ValueDataMember = "Value"
            });

            treeMap.DataAdapter = dataAdapter;
        }

        #region #RangeColorizer
        void CreateTreeMapColorizer() {
            TreeMapRangeColorizer colorizer = new TreeMapRangeColorizer();
            colorizer.Palette = Palette.CreatePalette( 
                Color.FromArgb(110, 201, 90),
                Color.FromArgb(227, 227, 51),
                Color.FromArgb(255, 93, 23)
            );
            colorizer.RangeStops.Add(1);
            colorizer.RangeStops.Add(64);
            colorizer.RangeStops.Add(256);
            colorizer.RangeStops.Add(1024);

            treeMap.Colorizer = colorizer;
        }
        #endregion #RangeColorizer

        List<CountryStatistics> CreateStatistics() {
            List<CountryStatistics> statistics = new List<CountryStatistics>();
            XDocument doc = XDocument.Load("..\\..\\Data\\EnergyStatistic.xml");
            foreach(XElement xCountry in doc.Element("ArrayOfEnergyStatistic").Elements("CountryEnergyInfo")) {
                CountryStatistics countryStatistics = new CountryStatistics();
                countryStatistics.Name = xCountry.Attribute("Country").Value;
                foreach(XElement xEnergyInfo in xCountry.Elements("EnergyStatistic")) {
                    countryStatistics.EnergyStatistics.Add(new EnergyInfo {
                        Type = xEnergyInfo.Attribute("TypeName").Value,
                        Value = Convert.ToDouble(xEnergyInfo.Attribute("Value").Value)
                    });
                }
                statistics.Add(countryStatistics);
            }
            return statistics;
        }
    }
}
