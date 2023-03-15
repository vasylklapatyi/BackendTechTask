using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NodeAlreadyExistsException : SecureException
    {
        public NodeAlreadyExistsException() : base("Node with the specified name already exists in the tree")
        {
        }
    }
}
