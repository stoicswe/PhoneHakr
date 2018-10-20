using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace Phone_Hackr
{
    class Phone
    {
        const string accountSid = "";
        const string authToken = "";
        const string phoneNumer = "";

        public Phone()
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public void MakeCall(string number, string messageType, string fromNumber = phoneNumer)
        {
            if(messageType == "spammer"){
                var call = CallResource.Create(
                    record: true,
                    url: new Uri("https://handler.twilio.com/twiml/EHbd076091c0fbbdf8fdb55fe2c2a02427"),
                    to: new Twilio.Types.PhoneNumber(number),
                    from: new Twilio.Types.PhoneNumber(fromNumber)
                );
                Console.WriteLine("Call to: {0} From: {1} @ resource ID: {2}", call.ToFormatted, call.FromFormatted, call.Sid);
            } else if(messageType == "custom"){
                var call = CallResource.Create(
                    record: true,
                    url: new Uri("https://handler.twilio.com/twiml/EH2539525c80482e3d29b09de24ea549d2"),
                    to: new Twilio.Types.PhoneNumber(number),
                    from: new Twilio.Types.PhoneNumber(fromNumber)
                );
                Console.WriteLine("Call to: {0} From: {1} @ resource ID: {2}", call.ToFormatted, call.FromFormatted, call.Sid);
            }
        }

        public void SendText(string number, string fromNumber = phoneNumer)
        {
            Console.Write("Message> ");
            var m = Console.ReadLine();
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(fromNumber),
                body: m,
                to: new Twilio.Types.PhoneNumber(number)
            );
            Console.WriteLine("Text to: {0} From: {1} @ resource ID: {2}", message.To, message.From, message.Sid);
        }

        public void SpamCall(string number, int amount, string fromNumber = phoneNumer)
        {
            var call = CallResource.Create(
                record: true,
                url: new Uri("https://handler.twilio.com/twiml/EHbd076091c0fbbdf8fdb55fe2c2a02427"),
                to: new Twilio.Types.PhoneNumber(number),
                from: new Twilio.Types.PhoneNumber(fromNumber)
            );
            for(int i = 0; i <= amount; i++)
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", call.ToFormatted, call.FromFormatted, call.Sid, call.Status, call.Duration);
        }

        public void SpamText(string number, int amount, string fromNumber = phoneNumer)
        {
            Console.Write("Message> ");
            var m = Console.ReadLine();
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(fromNumber),
                body: m,
                to: new Twilio.Types.PhoneNumber(number)
            );
            for(int i = 0; i <= amount; i++)
                Console.WriteLine("Text to: {0} From: {1} @ resource ID: {2}", message.To, message.From, message.Sid);
        }

        public void GenerateTwiml(string meaage)
        {
            var voice = new VoiceResponse();
            voice.Say(meaage);
            Console.WriteLine(voice.ToString());
        }
    }
}