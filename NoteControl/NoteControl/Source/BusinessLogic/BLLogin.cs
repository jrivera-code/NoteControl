﻿using NoteControl.Source.DataAccess.Source;
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
        public bool userExist(string userName, string password)
        {
            try
            {
               return _da.userExist(userName.ToUpper(), password);
              
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void CreateDataBase() {
            try
            {
                _da.CreateDataBase();

            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Requiere aver pasado por userExist
        /// </summary>
        public Usuario getUser()
        {
            try
            {
                return _da.getUser();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
