using FinalProject2.DAO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.Facades
{
   public class TestingFacade
    {
        TestingDAO testingDAO = new TestingDAO();

        public void ClearDB()
        {
            testingDAO.ExecuteNonQuery("call sp_delete_all_tables()");
        }
    }
}
