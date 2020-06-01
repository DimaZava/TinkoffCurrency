using System;

namespace Operation
{
	public struct Item
	{
		public enum FinanceType
		{
			Debit,
			Credit
		}

		string TransactionID;
		FinanceType Type;
		DateTime TransactionDate;
		string Currency;
		decimal Value;
		decimal ChangeRate;

		public Item(
			string transactionID,
			FinanceType type,
			DateTime transactionDate,
			string currency,
			decimal value,
			decimal changeRate
			)
		{
			TransactionID = transactionID;
			Type = type;
			TransactionDate = transactionDate;
			Currency = currency;
			Value = value;
			ChangeRate = changeRate;
		}
	}

	public static class FinanceTypeExtensions
	{
		public static String StringValueFrom(this Item.FinanceType type)
		{
			switch (type)
			{
				case Item.FinanceType.Debit:
					return "Debit";
				case Item.FinanceType.Credit:
					return "Credit";
				default: throw new ArgumentException("Unknown Type");
			}
		}
	}
}