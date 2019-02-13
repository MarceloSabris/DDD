﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ItemVirtualWS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ItemVirtualEntradaDTO", Namespace="http://www.suanova.com/ItemVirtual/DTO")]
    public partial class ItemVirtualEntradaDTO : object
    {
        
        private long GerencialIdField;
        
        private int IdUnidadeNegocioField;
        
        private string UsuarioField;
        
        private byte SequencialField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long GerencialId
        {
            get
            {
                return this.GerencialIdField;
            }
            set
            {
                this.GerencialIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUnidadeNegocio
        {
            get
            {
                return this.IdUnidadeNegocioField;
            }
            set
            {
                this.IdUnidadeNegocioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario
        {
            get
            {
                return this.UsuarioField;
            }
            set
            {
                this.UsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public byte Sequencial
        {
            get
            {
                return this.SequencialField;
            }
            set
            {
                this.SequencialField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseSaidaGenericoDTO", Namespace="http://www.suanova.com/DTO")]
    public partial class BaseSaidaGenericoDTO : object
    {
        
        private bool ErroField;
        
        private string[] MensagensField;
        
        private System.Guid ProtocoloField;
        
        private string TipoDeErroField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Erro
        {
            get
            {
                return this.ErroField;
            }
            set
            {
                this.ErroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Mensagens
        {
            get
            {
                return this.MensagensField;
            }
            set
            {
                this.MensagensField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Guid Protocolo
        {
            get
            {
                return this.ProtocoloField;
            }
            set
            {
                this.ProtocoloField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoDeErro
        {
            get
            {
                return this.TipoDeErroField;
            }
            set
            {
                this.TipoDeErroField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.suanova.com/", ConfigurationName="ItemVirtualWS.ItemVirtual")]
    public interface ItemVirtual
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.suanova.com/ItemVirtual/IncluirIVE", ReplyAction="http://www.suanova.com/ItemVirtual/IncluirIVEResponse")]
        System.Threading.Tasks.Task<ItemVirtualWS.BaseSaidaGenericoDTO> IncluirIVEAsync(ItemVirtualWS.ItemVirtualEntradaDTO item);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface ItemVirtualChannel : ItemVirtualWS.ItemVirtual, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class ItemVirtualClient : System.ServiceModel.ClientBase<ItemVirtualWS.ItemVirtual>, ItemVirtualWS.ItemVirtual
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ItemVirtualClient() : 
                base(ItemVirtualClient.GetDefaultBinding(), ItemVirtualClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ItemVirtual.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemVirtualClient(EndpointConfiguration endpointConfiguration) : 
                base(ItemVirtualClient.GetBindingForEndpoint(endpointConfiguration), ItemVirtualClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemVirtualClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ItemVirtualClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemVirtualClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ItemVirtualClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemVirtualClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ItemVirtualWS.BaseSaidaGenericoDTO> IncluirIVEAsync(ItemVirtualWS.ItemVirtualEntradaDTO item)
        {
            return base.Channel.IncluirIVEAsync(item);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ItemVirtual))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ItemVirtual))
            {
                return new System.ServiceModel.EndpointAddress("http://servicosloja.casasbahia.com.br/ItemVirtual.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ItemVirtualClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ItemVirtual);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ItemVirtualClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ItemVirtual);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ItemVirtual,
        }
    }
}
