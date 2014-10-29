using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommitOperation
    {
        private static CommitOperation _CommitOperation;
        private CommitOperation()
        {
            Success = true;
        }
        public static CommitOperation GetCommitOperation
        {
            get { return _CommitOperation ?? (_CommitOperation = new CommitOperation()); }
        }
        public bool Success { get; set; }

        public object OperationId { get; set; }

        public string Message { get; set; }

        public string Error { get; set; }
        

        
    }
}
