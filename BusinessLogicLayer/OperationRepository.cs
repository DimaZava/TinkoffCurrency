using System;
using System.Collections.Generic;
using static Operation.Item;
using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

namespace Operation
{
	public sealed class Repository
	{
		private static readonly Lazy<Repository> lazy =
			new Lazy<Repository>(() => new Repository());

		public static Repository Instance => lazy.Value;

		List<Item> operations = new List<Item>();

		private Repository()
		{
		}

		void AddOperationFrom(SpreadSheet.Row row)
		{
			new Item("id", FinanceType.Debit, new DateTime(), "EUR", new Decimal(22.2), new Decimal(55.5));
		}
	}
}