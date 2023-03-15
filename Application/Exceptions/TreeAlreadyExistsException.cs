using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class TreeAlreadyExistsException : SecureException
{
	public TreeAlreadyExistsException() : base("A tree with the given name already exists!")
	{

	}
}
