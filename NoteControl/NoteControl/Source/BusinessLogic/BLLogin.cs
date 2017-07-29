using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.BusinessLogic
{
   public class BLLogin
    {
        DALogin _da = new DALogin();
        public bool UserExist(string userName, string password)
        {
            try
            {
               return _da.UserExist(userName.ToUpper(), password);
              
            }
            catch 
            {
                throw;
            }

        }
        public void CreateDataBase() {
            try
            {
                _da.CreateDataBase();

            }
            catch 
            {
                throw;
            }

        }

        public bool DataBaseExist()
        {
            try
            {
                return _da.DataBaseExist();
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Requiere aver pasado por userExist
        /// </summary>
        public Usuario GetUser()
        {
            try
            {
                return _da.GetUser();
            }
            catch
            {
                throw;
            }
        }
    }
}
