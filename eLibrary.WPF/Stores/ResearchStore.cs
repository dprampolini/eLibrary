using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibrary.WPF.Stores
{
    public class ResearchStore
    {
        public string _research;

        public string Research
        {
            get
            {
                return _research;
            }
            set
            {
                _research = value;
                ResearchChanged?.Invoke();
            }
        }

        public event Action ResearchChanged;

    }
}
