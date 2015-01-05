<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8">
    <title>一张明信片计划 数读复旦</title>
    <link rel="stylesheet" type="text/css" href="/css/reset.css">
    <link rel="stylesheet" type="text/css" href="/css/home.css">
</head>
<body>
    <div>
        <div class="container">
            <div class="left">
                <div id="map" class="map"></div>
            </div>
            <div class="right">
                <div class="title">
                    一张明信片计划
                </div>
                <div class="count">
                    <p>截至2014年12月31日，已收到世界各地的明信片共</p>
                    <p class="total"><span class="totalNum">1731</span>张</p>

                </div>
                <div class="sidebar">
                    <div class="sideTitle">
                        <div class="sideTitleTab">寄出地排行</div>
                        <div class="sideTitleTab">来信摘录</div>
                        <div class="sideTitleTab">活动简介</div>
                        <div class="clear"></div>
                    </div>
                    <div class="sideContentContainer">
                        <div id="topSender" class="sideContent" style="display: none">
                            <p>1.上海</p>
                            <p>2.上海</p>
                            <p>3.上海</p>
                            <p>4.上海</p>
                            <p>5.上海</p>
                        </div>
                        <div id="letterSummary" class="sideContent">
                            <p>这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化</p>
                            <p>这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化这是一个神奇的可视化</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
        <script type="text/javascript" src="js/echarts-all.js"></script>
        <script type="text/javascript" src="js/data.js"></script>
        <script type="text/javascript" src="js/main.js"></script>
    </div>
</body>
</html>
