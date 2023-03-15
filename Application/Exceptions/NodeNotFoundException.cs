using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class NodeNotFoundException : SecureException
{
	public NodeNotFoundException() : base("The item with given id was not found")
	{

	}
}
