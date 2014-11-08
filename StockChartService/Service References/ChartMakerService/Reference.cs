﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockChartService.ChartMakerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChartMakerService.webchartSoap")]
    public interface webchartSoap {
        
        // CODEGEN: Generating message contract since element name Source from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MakeChart", ReplyAction="*")]
        StockChartService.ChartMakerService.MakeChartResponse MakeChart(StockChartService.ChartMakerService.MakeChartRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MakeChart", ReplyAction="*")]
        System.Threading.Tasks.Task<StockChartService.ChartMakerService.MakeChartResponse> MakeChartAsync(StockChartService.ChartMakerService.MakeChartRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MakeChartRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MakeChart", Namespace="http://tempuri.org/", Order=0)]
        public StockChartService.ChartMakerService.MakeChartRequestBody Body;
        
        public MakeChartRequest() {
        }
        
        public MakeChartRequest(StockChartService.ChartMakerService.MakeChartRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MakeChartRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Source;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Width;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Height;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Type;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Title;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Legend;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Labeltitle;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Datatitle;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string BackgroundColor1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string BackgroundColor2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string GraphBackgroundColor1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string GraphBackgroundColor2;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public int Markers;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=13)]
        public int Border;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=14)]
        public int Shadow;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=15)]
        public int Alpha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string Codec;
        
        public MakeChartRequestBody() {
        }
        
        public MakeChartRequestBody(
                    string Source, 
                    int Width, 
                    int Height, 
                    string Type, 
                    string Title, 
                    string Legend, 
                    string Labeltitle, 
                    string Datatitle, 
                    string BackgroundColor1, 
                    string BackgroundColor2, 
                    string GraphBackgroundColor1, 
                    string GraphBackgroundColor2, 
                    int Markers, 
                    int Border, 
                    int Shadow, 
                    int Alpha, 
                    string Codec) {
            this.Source = Source;
            this.Width = Width;
            this.Height = Height;
            this.Type = Type;
            this.Title = Title;
            this.Legend = Legend;
            this.Labeltitle = Labeltitle;
            this.Datatitle = Datatitle;
            this.BackgroundColor1 = BackgroundColor1;
            this.BackgroundColor2 = BackgroundColor2;
            this.GraphBackgroundColor1 = GraphBackgroundColor1;
            this.GraphBackgroundColor2 = GraphBackgroundColor2;
            this.Markers = Markers;
            this.Border = Border;
            this.Shadow = Shadow;
            this.Alpha = Alpha;
            this.Codec = Codec;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MakeChartResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MakeChartResponse", Namespace="http://tempuri.org/", Order=0)]
        public StockChartService.ChartMakerService.MakeChartResponseBody Body;
        
        public MakeChartResponse() {
        }
        
        public MakeChartResponse(StockChartService.ChartMakerService.MakeChartResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MakeChartResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MakeChartResult;
        
        public MakeChartResponseBody() {
        }
        
        public MakeChartResponseBody(string MakeChartResult) {
            this.MakeChartResult = MakeChartResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface webchartSoapChannel : StockChartService.ChartMakerService.webchartSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class webchartSoapClient : System.ServiceModel.ClientBase<StockChartService.ChartMakerService.webchartSoap>, StockChartService.ChartMakerService.webchartSoap {
        
        public webchartSoapClient() {
        }
        
        public webchartSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public webchartSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public webchartSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public webchartSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        StockChartService.ChartMakerService.MakeChartResponse StockChartService.ChartMakerService.webchartSoap.MakeChart(StockChartService.ChartMakerService.MakeChartRequest request) {
            return base.Channel.MakeChart(request);
        }
        
        public string MakeChart(
                    string Source, 
                    int Width, 
                    int Height, 
                    string Type, 
                    string Title, 
                    string Legend, 
                    string Labeltitle, 
                    string Datatitle, 
                    string BackgroundColor1, 
                    string BackgroundColor2, 
                    string GraphBackgroundColor1, 
                    string GraphBackgroundColor2, 
                    int Markers, 
                    int Border, 
                    int Shadow, 
                    int Alpha, 
                    string Codec) {
            StockChartService.ChartMakerService.MakeChartRequest inValue = new StockChartService.ChartMakerService.MakeChartRequest();
            inValue.Body = new StockChartService.ChartMakerService.MakeChartRequestBody();
            inValue.Body.Source = Source;
            inValue.Body.Width = Width;
            inValue.Body.Height = Height;
            inValue.Body.Type = Type;
            inValue.Body.Title = Title;
            inValue.Body.Legend = Legend;
            inValue.Body.Labeltitle = Labeltitle;
            inValue.Body.Datatitle = Datatitle;
            inValue.Body.BackgroundColor1 = BackgroundColor1;
            inValue.Body.BackgroundColor2 = BackgroundColor2;
            inValue.Body.GraphBackgroundColor1 = GraphBackgroundColor1;
            inValue.Body.GraphBackgroundColor2 = GraphBackgroundColor2;
            inValue.Body.Markers = Markers;
            inValue.Body.Border = Border;
            inValue.Body.Shadow = Shadow;
            inValue.Body.Alpha = Alpha;
            inValue.Body.Codec = Codec;
            StockChartService.ChartMakerService.MakeChartResponse retVal = ((StockChartService.ChartMakerService.webchartSoap)(this)).MakeChart(inValue);
            return retVal.Body.MakeChartResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<StockChartService.ChartMakerService.MakeChartResponse> StockChartService.ChartMakerService.webchartSoap.MakeChartAsync(StockChartService.ChartMakerService.MakeChartRequest request) {
            return base.Channel.MakeChartAsync(request);
        }
        
        public System.Threading.Tasks.Task<StockChartService.ChartMakerService.MakeChartResponse> MakeChartAsync(
                    string Source, 
                    int Width, 
                    int Height, 
                    string Type, 
                    string Title, 
                    string Legend, 
                    string Labeltitle, 
                    string Datatitle, 
                    string BackgroundColor1, 
                    string BackgroundColor2, 
                    string GraphBackgroundColor1, 
                    string GraphBackgroundColor2, 
                    int Markers, 
                    int Border, 
                    int Shadow, 
                    int Alpha, 
                    string Codec) {
            StockChartService.ChartMakerService.MakeChartRequest inValue = new StockChartService.ChartMakerService.MakeChartRequest();
            inValue.Body = new StockChartService.ChartMakerService.MakeChartRequestBody();
            inValue.Body.Source = Source;
            inValue.Body.Width = Width;
            inValue.Body.Height = Height;
            inValue.Body.Type = Type;
            inValue.Body.Title = Title;
            inValue.Body.Legend = Legend;
            inValue.Body.Labeltitle = Labeltitle;
            inValue.Body.Datatitle = Datatitle;
            inValue.Body.BackgroundColor1 = BackgroundColor1;
            inValue.Body.BackgroundColor2 = BackgroundColor2;
            inValue.Body.GraphBackgroundColor1 = GraphBackgroundColor1;
            inValue.Body.GraphBackgroundColor2 = GraphBackgroundColor2;
            inValue.Body.Markers = Markers;
            inValue.Body.Border = Border;
            inValue.Body.Shadow = Shadow;
            inValue.Body.Alpha = Alpha;
            inValue.Body.Codec = Codec;
            return ((StockChartService.ChartMakerService.webchartSoap)(this)).MakeChartAsync(inValue);
        }
    }
}
