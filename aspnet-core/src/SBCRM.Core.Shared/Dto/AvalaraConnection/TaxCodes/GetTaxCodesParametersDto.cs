using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Dto.AvalaraConnection.TaxCodes
{
    public class GetTaxCodesParametersDto
    {
        public GetTaxCodesParametersDto(string taxCodeType, string taxCode, string parentTaxCode, string description)
        {
            if (!string.IsNullOrWhiteSpace(taxCodeType))
            {
                Filter = "taxCodeTypeId eq " + taxCodeType;
            }
            if (!string.IsNullOrWhiteSpace(taxCode))
            {
                if(taxCode.IndexOf('%') <= 0)
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "taxCode contains '" + taxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and taxCode contains '" + taxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }
                else if(taxCode.EndsWith("%"))
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "taxCode startswith '" + taxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and taxCode startswith '" + taxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }
                
            }
            if (!string.IsNullOrWhiteSpace(parentTaxCode))
            {
                if (parentTaxCode.IndexOf('%') <= 0)
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "parentTaxCode contains '" + parentTaxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and parentTaxCode contains '" + parentTaxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }
                else if (parentTaxCode.EndsWith("%"))
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "parentTaxCode startswith '" + parentTaxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and parentTaxCode startswith '" + parentTaxCode.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }

            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.IndexOf('%') <= 0)
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "description contains '" + description.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and description contains '" + description.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }
                else if (description.EndsWith("%"))
                {
                    if (string.IsNullOrWhiteSpace(Filter))
                    {
                        Filter = "description startswith '" + description.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                    else
                    {
                        Filter = Filter + " and description startswith '" + description.Trim().Replace("%", "").Replace("'", "''") + "'";
                    }
                }

            }
            OrderBy = "TaxCode";
        }

        public string Filter { get; set; }

        public string Include { get; set; }

        public string Top { get; set; }

        public string Skip { get; set; }

        public string OrderBy { get; set; }
    }
}
