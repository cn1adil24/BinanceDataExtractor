using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Models
{
    [Table("Candlestick")]
    public class Candlestick
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Kline Open time in unix time format
        /// </summary>
        public long OpenTime { get; set; }

        /// <summary>
        /// Open Price
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// High Price
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Low Price
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Close Price
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Kline Close time in unix time format
        /// </summary>
        public long CloseTime { get; set; }

        /// <summary>
        /// Quote Asset Volume
        /// </summary>
        public double QuoteVolume { get; set; }

        /// <summary>
        /// Number of Trades
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Taker buy base asset volume during this period
        /// </summary>
        public double TakerBuyVolume { get; set; }

        /// <summary>
        /// Taker buy quote asset volume during this period
        /// </summary>
        public double TakerBuyQuoteVolume { get; set; }

        /// <summary>
        /// Ignore
        /// </summary>
        public int Ignore { get; set; }
    }
}
