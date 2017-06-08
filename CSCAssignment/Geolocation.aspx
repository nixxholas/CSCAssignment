<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Geolocation.aspx.cs" Inherits="CSCAssignment.Geolocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #32373a;
            color: #FFFFFF;
        }

        #mainBody {
            background-color: #FFFFFF;
            height: 100%;
            color: #32373a;
        }

        .divMainTime {
            width: 350px;
            height: 30px;
            background-color: #fdd136;
            font-size: 14px;
            vertical-align: middle;
            padding-top: 5px;
        }

        #divLALO {
            font-size: 20px;
            float: right;
            margin-right: 10px;
        }
    </style>
</head>

<body>
    <div id="mainBody">
        <h1>Retrieve User's GeoLocation: latitude and longitude</h1>
        <br />
        <div class="divMainTime">
            <div style="float: left; font-size: 18px;">User&#39;s L and H :</div>
            <div id="divLALO"></div>
        </div>

        <button onclick="getLocation()">Try It</button>
        <div id="locationholder"></div>

        <div id="mapholder"></div>

        <div>
            <script type="text/javascript" src="http://j.maxmind.com/app/geoip.js"></script>
            <br />
            Country Code:
            <script type="text/javascript">document.write(geoip_country_code());</script>
            <br />
            Country Name:
            <script type="text/javascript">document.write(geoip_country_name());</script>
            <br />
            City:
            <script type="text/javascript">document.write(geoip_city());</script>
            <br />
            Region:
            <script type="text/javascript">document.write(geoip_region());</script>
            <br />
            Region Name:
            <script type="text/javascript">document.write(geoip_region_name());</script>
            <br />
            Latitude:
            <script type="text/javascript">document.write(geoip_latitude());</script>
            <br />
            Longitude:
            <script type="text/javascript">document.write(geoip_longitude());</script>
            <br />
            Postal Code:
            <script type="text/javascript">document.write(geoip_postal_code());</script>
        </div>
    </div>

    <script>
        var x = document.getElementById("demo");

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            var latlon = position.coords.latitude + "," + position.coords.longitude;

            var img_url = "http://maps.googleapis.com/maps/api/staticmap?center=" + latlon + "&zoom=14&size=400x300&sensor=false";

            document.getElementById("mapholder").innerHTML = "<img scr='" + img_url + "'>";

            document.getElementById("divLALO").innerHTML = latlon;
        }

        function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    x.innerHTML = "User denied the request for Geolocation.";
                    break;
                case error.POSITION_UNAVAILABLE:
                    x.innerHTML = "Location information is unavailable.";
                    break;
                case error.TIMEOUT:
                    x.innerHTML = "The request to get user location timed out.";
                    break;
                default:
                    x.innerHTML = "An unknown error occurred.";
                    break;
            }
        }
    </script>
</body>
</html>
