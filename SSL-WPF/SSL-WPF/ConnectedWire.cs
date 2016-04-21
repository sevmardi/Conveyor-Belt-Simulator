using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SSL_WPF
{
    /// <summary>
    /// This wire can update its position based on the gates it is actually connected to.
    /// It also updates its value when the origin terminal changes value.
    /// </summary>
    public class ConnectedWire : Wire
    {
        private SSL.TerminalID origin, dest;
        private SSL.AbstractSSL originSSL, destSSL;

        public SSL.TerminalID OriginTerminalID
        {
            get
            {
                return origin;
            }
        }

        public SSL.TerminalID DestTerminalID
        {
            get
            {
                return dest;
            }
        }

        public SSL.AbstractGate OriginGate
        {
            get
            {
                return originGate;
            }
        }

        public SSL.AbstractGate DestinationGate
        {
            get
            {
                return destSSL;
            }
        }
        public ConnectedWire(SSL.AbstractGate originGate, SSL.TerminalID origin, SSL.AbstractGate destGate, SSL.TerminalID dest)
            : base()
        {

            if (origin.isInput || !dest.isInput)
            {
                throw new ArgumentException("Can only connect output (origin) to input (dest)");
            }

            Value = false;
            this.originGate = originGate;
            this.destGate = destGate;
            this.origin = origin;
            this.dest = dest;
            //originGate.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(originGate_PropertyChanged);
            originGate.PropertyChanged += EventDispatcher.CreateBatchDispatchedHandler(originGate, originGate_PropertyChanged);
            Connect();


        }

        private void originGate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Value = ShowTrueFalse && originGate.Output[origin.ID];
        }

        public void Connect()
        {
            Origin = origin.t.TranslatePoint(new Point(5, 5), this);
            Destination = dest.t.TranslatePoint(new Point(5, 5), this);
        }

        private bool _showTF = true;

        public bool ShowTrueFalse
        {
            get
            {
                return _showTF;
            }
            set
            {
                _showTF = value;
                originGate_PropertyChanged(null, null);
            }
        }
    }
}
