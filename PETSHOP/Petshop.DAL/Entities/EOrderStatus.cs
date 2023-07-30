using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
	public enum EOrderStatus
	{
		Hazırlanıyor=1,
		Paketlendi,
		KargoyaVerildi,
		TeslimEdildi,
		İptaledildi
	}
}
