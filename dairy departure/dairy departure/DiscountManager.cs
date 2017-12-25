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

		public decimal Calculate(DateTime production, int IDprod)
		{
            //return Round(Convert.ToDecimal(getrandom.Next(3, 7) + getrandom.NextDouble()));
            decimal completedProcent = 0;
            int shelfLife = 0;

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
            decimal lifeProcent = (decimal)((DateTime.Today - production).TotalDays / shelfLife * 30);


            return planProcent + lifeProcent;
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