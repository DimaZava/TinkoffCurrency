// <copyright file="OperationItem.cs" company="Chinchilla Initiative">
// Copyright (c) Chinchilla Initiative. All rights reserved.
// </copyright>

namespace Operation
{
    using System;

    /// <summary>
    /// OperationItem struct contains necessary information from Excel operation row.
    /// </summary>
    public struct OperationItem : IEquatable<OperationItem>
    {
        /// <summary>
        /// Transaction ID.
        /// </summary>
        internal string TransactionID;

        /// <summary>
        /// Financial operation type.
        /// </summary>
        internal FinanceType Type;

        /// <summary>
        /// Transaction date.
        /// </summary>
        internal DateTime TransactionDate;

        /// <summary>
        /// Operation currency.
        /// </summary>
        internal string Currency;

        /// <summary>
        /// Operation value.
        /// </summary>
        internal decimal Value;

        /// <summary>
        /// Operation currency change rate.
        /// </summary>
        internal decimal ChangeRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationItem"/> struct.
        /// </summary>
        /// <param name="transactionID">Transaction ID.</param>
        /// <param name="type">Financial operation type.</param>
        /// <param name="transactionDate">Transaction date.</param>
        /// <param name="currency">Operation currency.</param>
        /// <param name="value">Operation value.</param>
        /// <param name="changeRate">Operation currency change rate.</param>
        public OperationItem(
            string transactionID,
            FinanceType type,
            DateTime transactionDate,
            string currency,
            decimal value,
            decimal changeRate)
        {
            this.TransactionID = transactionID;
            this.Type = type;
            this.TransactionDate = transactionDate;
            this.Currency = currency;
            this.Value = value;
            this.ChangeRate = changeRate;
        }

        /// <summary>
        /// Financial operation type.
        /// </summary>
        public enum FinanceType
        {
            /// <summary>
            /// Debit operation.
            /// </summary>
            Debit,

            /// <summary>
            /// Credit operation.
            /// </summary>
            Credit,
        }

        public static bool operator ==(OperationItem left, OperationItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OperationItem left, OperationItem right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is OperationItem)
            {
                return this.TransactionID == ((OperationItem)obj).TransactionID;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ this.TransactionID.GetHashCode(System.StringComparison.Ordinal);
                result = (result * 397) ^ (int)this.Type;
                result = (result * 397) ^ this.TransactionDate.GetHashCode();
                result = (result * 397) ^ this.Currency.GetHashCode(System.StringComparison.Ordinal);
                result = (result * 397) ^ this.Value.GetHashCode();
                result = (result * 397) ^ this.ChangeRate.GetHashCode();
                return result;
            }
        }

        /// <inheritdoc/>
        public bool Equals(OperationItem other)
        {
            return this.TransactionID == other.TransactionID;
        }
    }

    /// <summary>
    /// Financial operation type extensions.
    /// </summary>
    public static class FinanceTypeExtensions
    {
        /// <summary>
        /// Transforms financial operation type to corresponding string value.
        /// </summary>
        /// <param name="type">Current operation type.</param>
        /// <returns>Corresponding string value.</returns>
        public static string StringValueFrom(this OperationItem.FinanceType type) =>
            type switch
            {
                OperationItem.FinanceType.Debit => "Debit",
                OperationItem.FinanceType.Credit => "Credit",
                _ => throw new NotImplementedException(),
            };
    }
}