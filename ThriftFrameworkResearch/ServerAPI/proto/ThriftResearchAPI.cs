using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace ServerAPI.proto
{
    public class ThriftResearchAPI
    {
       
            public interface Iface
            {
                string TestSendHttpResearch(string parameter1, string parameter2);
#if SILVERLIGHT
      IAsyncResult Begin_TestSendHttpResearch(AsyncCallback callback, object state, string parameter1, string parameter2);
      string End_TestSendHttpResearch(IAsyncResult asyncResult);
#endif
            }

            public class Client : IDisposable, Iface
            {
                public Client(TProtocol prot) : this(prot, prot)
                {
                }

                public Client(TProtocol iprot, TProtocol oprot)
                {
                    iprot_ = iprot;
                    oprot_ = oprot;
                }

                protected TProtocol iprot_;
                protected TProtocol oprot_;
                protected int seqid_;

                public TProtocol InputProtocol
                {
                    get { return iprot_; }
                }
                public TProtocol OutputProtocol
                {
                    get { return oprot_; }
                }


                #region " IDisposable Support "
                private bool _IsDisposed;

                // IDisposable
                public void Dispose()
                {
                    Dispose(true);
                }


                protected virtual void Dispose(bool disposing)
                {
                    if (!_IsDisposed)
                    {
                        if (disposing)
                        {
                            if (iprot_ != null)
                            {
                                ((IDisposable)iprot_).Dispose();
                            }
                            if (oprot_ != null)
                            {
                                ((IDisposable)oprot_).Dispose();
                            }
                        }
                    }
                    _IsDisposed = true;
                }
                #endregion



#if SILVERLIGHT
      public IAsyncResult Begin_TestSendHttpResearch(AsyncCallback callback, object state, string parameter1, string parameter2)
      {
        return send_TestSendHttpResearch(callback, state, parameter1, parameter2);
      }

      public string End_TestSendHttpResearch(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_TestSendHttpResearch();
      }

#endif

                public string TestSendHttpResearch(string parameter1, string parameter2)
                {
#if !SILVERLIGHT
                    send_TestSendHttpResearch(parameter1, parameter2);
                    return recv_TestSendHttpResearch();

#else
        var asyncResult = Begin_TestSendHttpResearch(null, null, parameter1, parameter2);
        return End_TestSendHttpResearch(asyncResult);

#endif
                }
#if SILVERLIGHT
      public IAsyncResult send_TestSendHttpResearch(AsyncCallback callback, object state, string parameter1, string parameter2)
#else
                public void send_TestSendHttpResearch(string parameter1, string parameter2)
#endif
                {
                    oprot_.WriteMessageBegin(new TMessage("TestSendHttpResearch", TMessageType.Call, seqid_));
                    TestSendHttpResearch_args args = new TestSendHttpResearch_args();
                    args.Parameter1 = parameter1;
                    args.Parameter2 = parameter2;
                    args.Write(oprot_);
                    oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                    oprot_.Transport.Flush();
#endif
                }

                public string recv_TestSendHttpResearch()
                {
                    TMessage msg = iprot_.ReadMessageBegin();
                    if (msg.Type == TMessageType.Exception)
                    {
                        TApplicationException x = TApplicationException.Read(iprot_);
                        iprot_.ReadMessageEnd();
                        throw x;
                    }
                    TestSendHttpResearch_result result = new TestSendHttpResearch_result();
                    result.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    if (result.__isset.success)
                    {
                        return result.Success;
                    }
                    throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "TestSendHttpResearch failed: unknown result");
                }

            }
            public class Processor : TProcessor
            {
                public Processor(Iface iface)
                {
                    iface_ = iface;
                    processMap_["TestSendHttpResearch"] = TestSendHttpResearch_Process;
                }

                protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
                private Iface iface_;
                protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

                public bool Process(TProtocol iprot, TProtocol oprot)
                {
                    try
                    {
                        TMessage msg = iprot.ReadMessageBegin();
                        ProcessFunction fn;
                        processMap_.TryGetValue(msg.Name, out fn);
                        if (fn == null)
                        {
                            TProtocolUtil.Skip(iprot, TType.Struct);
                            iprot.ReadMessageEnd();
                            TApplicationException x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                            x.Write(oprot);
                            oprot.WriteMessageEnd();
                            oprot.Transport.Flush();
                            return true;
                        }
                        fn(msg.SeqID, iprot, oprot);
                    }
                    catch (IOException)
                    {
                        return false;
                    }
                    return true;
                }

                public void TestSendHttpResearch_Process(int seqid, TProtocol iprot, TProtocol oprot)
                {
                    TestSendHttpResearch_args args = new TestSendHttpResearch_args();
                    args.Read(iprot);
                    iprot.ReadMessageEnd();
                    TestSendHttpResearch_result result = new TestSendHttpResearch_result();
                    result.Success = iface_.TestSendHttpResearch(args.Parameter1, args.Parameter2);
                    oprot.WriteMessageBegin(new TMessage("TestSendHttpResearch", TMessageType.Reply, seqid));
                    result.Write(oprot);
                    oprot.WriteMessageEnd();
                    oprot.Transport.Flush();
                }

            }


#if !SILVERLIGHT
            [Serializable]
#endif
            public partial class TestSendHttpResearch_args : TBase
            {
                private string _parameter1;
                private string _parameter2;

                public string Parameter1
                {
                    get
                    {
                        return _parameter1;
                    }
                    set
                    {
                        __isset.parameter1 = true;
                        this._parameter1 = value;
                    }
                }

                public string Parameter2
                {
                    get
                    {
                        return _parameter2;
                    }
                    set
                    {
                        __isset.parameter2 = true;
                        this._parameter2 = value;
                    }
                }


                public Isset __isset;
#if !SILVERLIGHT
                [Serializable]
#endif
                public struct Isset
                {
                    public bool parameter1;
                    public bool parameter2;
                }

                public TestSendHttpResearch_args()
                {
                }

                public void Read(TProtocol iprot)
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.String)
                                {
                                    Parameter1 = iprot.ReadString();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            case 2:
                                if (field.Type == TType.String)
                                {
                                    Parameter2 = iprot.ReadString();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }

                public void Write(TProtocol oprot)
                {
                    TStruct struc = new TStruct("TestSendHttpResearch_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (Parameter1 != null && __isset.parameter1)
                    {
                        field.Name = "parameter1";
                        field.Type = TType.String;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteString(Parameter1);
                        oprot.WriteFieldEnd();
                    }
                    if (Parameter2 != null && __isset.parameter2)
                    {
                        field.Name = "parameter2";
                        field.Type = TType.String;
                        field.ID = 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteString(Parameter2);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }

                public override string ToString()
                {
                    StringBuilder sb = new StringBuilder("TestSendHttpResearch_args(");
                    sb.Append("Parameter1: ");
                    sb.Append(Parameter1);
                    sb.Append(",Parameter2: ");
                    sb.Append(Parameter2);
                    sb.Append(")");
                    return sb.ToString();
                }

            }


#if !SILVERLIGHT
            [Serializable]
#endif
            public partial class TestSendHttpResearch_result : TBase
            {
                private string _success;

                public string Success
                {
                    get
                    {
                        return _success;
                    }
                    set
                    {
                        __isset.success = true;
                        this._success = value;
                    }
                }


                public Isset __isset;
#if !SILVERLIGHT
                [Serializable]
#endif
                public struct Isset
                {
                    public bool success;
                }

                public TestSendHttpResearch_result()
                {
                }

                public void Read(TProtocol iprot)
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 0:
                                if (field.Type == TType.String)
                                {
                                    Success = iprot.ReadString();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }

                public void Write(TProtocol oprot)
                {
                    TStruct struc = new TStruct("TestSendHttpResearch_result");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();

                    if (this.__isset.success)
                    {
                        if (Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.String;
                            field.ID = 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteString(Success);
                            oprot.WriteFieldEnd();
                        }
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }

                public override string ToString()
                {
                    StringBuilder sb = new StringBuilder("TestSendHttpResearch_result(");
                    sb.Append("Success: ");
                    sb.Append(Success);
                    sb.Append(")");
                    return sb.ToString();
                }

            }

        }
    }
