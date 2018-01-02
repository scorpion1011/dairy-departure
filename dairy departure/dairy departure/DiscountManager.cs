using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dairy_departure
{
	class DiscountManager
	{

		private static readonly Random getrandom = new Random();
        decimal completedProcent = 0;
        int shelfLife = 0;
        decimal lifeProcent;
        int idPlan = 0;


        public decimal Calculate(DateTime production, int IDprod, DateTime dateSell)
		{
            

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT TOP 1 cccc.id_plan, (cccc.AMONT + cccc.[Time]) / 2 as VVVV
FROM (
SELECT Sp.id_plan, (Sum([Sl.Count])/MIN(SpP.Amount)*100) as AMONT, ((Sp.Date_to-Date())/(Sp.Date_to-Sp.Date_from)*100) AS [Time]

FROM Sells AS Sl, Supply AS S, Selles_plan AS Sp, SellesPlan_Product AS SpP

WHERE Sl.ID_supply=[S].[ID_supply] AND Sl.[Date_sell]>Sp.Date_from And Sl.[Date_sell]<Sp.Date_to AND S.ID_product=[SpP].[ID_product] AND Sp.ID_plan=[SpP].[ID_plan]
AND S.ID_product = @ID_product

GROUP BY Sp.id_plan, Sp.Date_to, Sp.Date_from

Having (Sum([Sl.Count]/SpP.Amount)*100) <100
) as cccc

ORDER BY (cccc.AMONT + cccc.[Time]) / 2;";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_product", IDprod);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idPlan = reader.GetInt32(0);
                            completedProcent = (decimal)Math.Round(reader.GetDouble(1));
                        }
                    }
                    conn.Close();
                }
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"select ShelfLife from Product where ID_product = @ID_product";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_product", IDprod);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shelfLife = reader.GetInt32(0);
                        }
                    }
                    conn.Close();
                }
            }

            decimal planProcent;

            if (completedProcent > 30)
            {
                planProcent = 0;
            }
            else
            {
                planProcent = 30 - completedProcent;
            }
            lifeProcent = (decimal)((dateSell - production).TotalDays / shelfLife * 30);

            return Math.Round(planProcent + lifeProcent);
        }

        public List<string> Information(int IDsell) //Date of selling : {0} Product : {1} Shelf Life : {2} Date Of Production : {3} % of corruption : {4} Fired Plan Information : {5}
                    //% of Completing plan : {6}
        {
            List<string> info = new List<string>();
            int IDproduct = 0;
            int IDsupply = 0;
            int IDmanufacturer = 0;
            DateTime DateOfProduction = DateTime.Now;
            string plan = "";
            DateTime dateOFSelling = DateTime.Now;
            string product = "";

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"select p.ID_product, m.ID_manufacturer, s.ID_supply, s.Date_Production, sl.Date_sell from Sells as sl, Supply as s, Product as p, Manufacturer as m where sl.ID_sell = @ID_sell and sl.ID_supply = s.ID_supply 
                                and s.ID_product = p.ID_product and p.ID_manufacturer = m.ID_manufacturer";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_sell", IDsell);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IDproduct = reader.GetInt32(0);
                            IDmanufacturer = reader.GetInt32(1);
                            IDsupply = reader.GetInt32(2);
                            DateOfProduction = reader.GetDateTime(3);
                            dateOFSelling = reader.GetDateTime(4);
                        }
                        
                    }
                    conn.Close();
                }
            }
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"select m.Name_manufacturer, p.Name_product, p.[Mass/volume], p.[%-fat], p.[ShelfLife] from Product as p, Manufacturer as m
                                where p.ID_manufacturer = m.ID_manufacturer and m.ID_manufacturer = @idM and p.ID_product = @idP";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@idM", IDmanufacturer);
                    comm.Parameters.AddWithValue("@ID_sell", IDproduct);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetInt32(3) + " - " + reader.GetInt32(4);
                        }
                    }
                    conn.Close();
                }

            }

            Calculate(DateOfProduction, IDproduct, dateOFSelling);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"select sp.Date_from, sp.Date_to, spp.Amount from Selles_plan as sp, SellesPlan_Product as spp
                                where sp.ID_plan = spp.ID_plan and sp.ID_plan = @id_plan and spp.ID_product = @id_product";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id_plan", idPlan);
                    comm.Parameters.AddWithValue("@ID_product", IDproduct);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            plan = reader.GetDateTime(0).ToString("dd.MM.yyyy") + " - " + reader.GetDateTime(1).ToString("dd.MM.yyyy") + ". With amount of: " + reader.GetInt32(2);
                        }
                    }
                    conn.Close();
                }

            }

            info.Add(dateOFSelling.ToString("dd.MM.yyyy"));
            info.Add(product);
            info.Add(shelfLife.ToString()+" days");
            info.Add(DateOfProduction.ToString("dd.MM.yyyy"));
            info.Add(Math.Round(lifeProcent/3*10).ToString()+"%");
            info.Add(plan);
            info.Add(Math.Round(completedProcent).ToString()+"%");

            return info;
        }

		public decimal CalculatePrice(decimal price, decimal discount)
		{
			return Round(price - price * discount / 100);
		}

		public decimal Round(decimal price)
		{
			return System.Math.Round(price, 2);
		}

		public string Format(decimal price)
		{
			return price.ToString("0.00");
		}

	}
}