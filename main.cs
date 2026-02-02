import Fiddler;


class Handlers
{

    static function OnBeforeRequest(oSession: Session)
    {
        if (!oSession.hostname.EndsWith("hypergryph.com"))
        {
            oSession.Ignore();
            return;
        }

        if (oSession.HTTPMethodIs("CONNECT"))
        {
            oSession.oFlags["x-ReplyWithTunnel"] = "placeholder string";
            return;
        }

        oSession.oRequest.headers.UriScheme = "http";
        oSession.host = "127.0.0.1:8443";
    }

}

