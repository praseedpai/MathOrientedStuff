using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapReduce
{
    static class  Program
    {

	
        
        static void Main(string[] args)
        {

		Func<int, int> factorial = (n) => {
			Func<int, int> fIterator = null; //Work-around for "use of unassigned variable" error!
			fIterator = (m) => (m < 2) ? 1 : m * fIterator(m - 1);
			return fIterator(n);
		};

		Func<int, int> factorialTCO = (n) =>{
			Func<int, int, int> fIterator = null;
			fIterator = (product, i) =>(i < 2) ? product : fIterator(product * i, i - 1);
			return fIterator(1, n);
		};

		Func<int, int> factorialTramp = (n) =>  {
			Func<int, int, int> trampoline = null;
			Func<int, int, int> fIterator = (product, i) =>(i < 2) ? product : trampoline(product * i, i - 1);
			trampoline = (product, i) => fIterator(product * i, i - 1);
			return trampoline(1, n);
		};


        }
    }
}
