﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class State
    {
        private readonly DataModel.State _state;

        public State()
        {
            _state = new DataModel.State();
        }

        public List<Entities.State> GetStateByCountryId(Int32 countryId)
        {
            return _state.GetStateByCountryId(countryId);
        }
    }
}
