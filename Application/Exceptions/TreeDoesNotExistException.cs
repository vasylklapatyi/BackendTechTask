using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class TreeDoesNotExistException : SecureException
{
	public TreeDoesNotExistException() : base("The tree does not exist")
	{

	}
}
