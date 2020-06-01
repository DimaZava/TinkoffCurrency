// <copyright file="OperationRepository.cs" company="Chinchilla Initiative">
// Copyright (c) Chinchilla Initiative. All rights reserved.
// </copyright>

namespace Operation
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Operation.Item;
    using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

    public sealed class OperationRepository
    {
        private static readonly Lazy<OperationRepository> Lazy =
            new Lazy<OperationRepository>(() => new OperationRepository());

        public static OperationRepository Instance => Lazy.Value;

        private List<Item> operations = new List<Item>();

        private OperationRepository()
        {
        }

        public void AddOperationFrom(SpreadSheet.Row row)
        {
            //new Item("id", FinanceType.Debit, new DateTime(), "EUR", new Decimal(22.2), new Decimal(55.5));
            var currentColumnIndex = 0;

            string TransactionID;
            FinanceType Type;
            DateTime TransactionDate;
            string Currency;
            decimal Value;
            decimal ChangeRate;
            foreach (SpreadSheet.Cell cell in row.Elements<SpreadSheet.Cell>())
            {
                Column currentColumn = (Column)currentColumnIndex;
                switch (currentColumn)
                {
                    case Column.AccountNumber:
                        break;
                    case Column.TransactionID:
                        TransactionID = cell.CellValue.Text;
                        break;
                    case Column.Type:
                        if (cell.CellValue.Text == FinanceType.Debit.StringValueFrom())
                        {
                            Type = FinanceType.Debit;
                        }
                        else if (cell.CellValue.Text == FinanceType.Credit.StringValueFrom())
                        {
                            Type = FinanceType.Credit;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case Column.OperationCategory:
                        break;
                    case Column.Status:
                        break;
                    case Column.OperationCreateDate:
                        break;
                    case Column.AuthorizationDate:
                        break;
                    case Column.TransactionDate:
                        try
                        {
                            TransactionDate = DateTime.ParseExact(cell.CellValue.Text, "yyyy.MM.dd", null);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0} Exception caught.", e);
                        }
                        break;
                    case Column.OriginalOperationID:
                        break;
                    case Column.OperationSumInOperationCurrency:
                        break;
                    case Column.Currency:
                        Currency = cell.CellValue.Text;
                        break;
                    case Column.SumInAccountCurrency:
                        break;
                    case Column.Contragent:
                        break;
                    case Column.ContragentINN:
                        break;
                    case Column.ContragentKPP:
                        break;
                    case Column.ContragentAccount:
                        break;
                    case Column.ContragentBankBIK:
                        break;
                    case Column.ContragentBankCorrespondenAccount:
                        break;
                    case Column.ContragentBankName:
                        break;
                    case Column.PaymentPurpose:
                        //{VO01010} Продажа валюты 35 евро по курсу 78.4 руб. / евро по поручению №115 от 19.05.2020
                        string pattern = "(\\d+(?:\\.\\d+)?)";
                        var matches = Regex.Matches(cell.CellValue.Text, pattern);

                        if (matches.Count >= 3)
                        {
                            Value = decimal.Parse(matches[1].Value);
                            ChangeRate = decimal.Parse(matches[2].Value);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private enum Column
        {
            AccountNumber,
            TransactionID,
            Type,
            OperationCategory,
            Status,
            OperationCreateDate,
            AuthorizationDate,
            TransactionDate,
            OriginalOperationID,
            OperationSumInOperationCurrency,
            Currency,
            SumInAccountCurrency,
            Contragent,
            ContragentINN,
            ContragentKPP,
            ContragentAccount,
            ContragentBankBIK,
            ContragentBankCorrespondenAccount,
            ContragentBankName,
            PaymentPurpose,
        }
    }
}