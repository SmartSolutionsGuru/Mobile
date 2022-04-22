using Newtonsoft.Json;

namespace SmartSolutions.Mobile.Api
{
    public class BaseResponse
    {
        /// <summary>
        /// Initializes a new instance of the ResponseException class.
        /// </summary>
        public BaseResponse() { }

        /// <summary>
        /// Initializes a new instance of the ResponseException class.
        /// </summary>
        public BaseResponse(int? status = default(int?), string message = default(string), object data = default(object))
        {
            Status = status;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Status
        /// &lt;list
        /// type="ResponseStatus"&gt;&lt;item&gt;OK&lt;/item&gt;&lt;item&gt;Info&lt;/item&gt;&lt;item&gt;Error&lt;/item&gt;&lt;item&gt;Warning&lt;/item&gt;&lt;/list&gt;
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int? Status { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }


    }
    public class BaseResponse<T> : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public new T Data
        {
            get
            {
                return (T)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
    }
}
