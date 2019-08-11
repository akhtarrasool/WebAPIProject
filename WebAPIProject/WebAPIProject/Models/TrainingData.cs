using System;
using WebAPIProject.Entities;

namespace WebAPIProject.Models
{
    public class TrainingData
    {
        #region Private Members

        private string _trainingName;

        private DateTime _startDate;

        private DateTime _endDate;

        #endregion

        #region Public Members
        public string TrainingName
        {
            get { return _trainingName; }
            set { _trainingName = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string ValidateDates(out int days)
        {
            days = -1;
            if (_startDate != DateTime.MinValue && _endDate != DateTime.MinValue)
            {
                if ( _endDate < _startDate)
                {                    
                    return Constants.ResponseMessages.Training_Save_Date_Diff;
                }

                days = _endDate.Subtract(_startDate).Days + 1;
                return Constants.ResponseMessages.Training_Save_Date_Valid;
            }

            return Constants.ResponseMessages.Training_Save_Date_Invalid;

        }

        #endregion
    }
}
