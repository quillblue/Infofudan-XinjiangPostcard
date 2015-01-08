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
                <div id="map" class="leftContent"></div>
                <div id="cardWall" class="leftContent cardWall" style="display:none">
                    <p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p><p>1</p>
                </div>
            </div>
            <div class="right">
                <div class="title">
                    一张明信片计划
                </div>
                <div class="count">
                    <p>截至2014年12月31日，已收到各地的明信片共</p>
                    <p class="total"><span class="totalNum">1461</span>张</p>

                </div>
                <div class="sidebar">
                    <div class="sideMenu">
                        <a id="mapChange" class="sideBtn sideBtnLeft" href="#">切换地图视角</a>
                        <a id="cardDisplaySwitch" class="sideBtn sideBtnRight" href="#">显示来信摘录</a>
                        <div class="clear"></div>
                    </div>
                    <div class="sideTitle">
                        <div class="sideTitleTab">计划简介</div>
                        <div class="clear"></div>
                    </div>
                    <div class="sideContentContainer">

                        <div id="intro" class="sideContent">
                            <p>2014年10月8日，复旦大学研究生支教团在“复旦支教在新疆”微信公共平台发起了“一张明信片计划”。10月21日，我们收到第一张明信片，来自上海；当周周末，我们收到的明信片达到299张。</p>

                            <p>这些明信片成了一扇窗口，在我们看来，这是他们接触外面世界最简单但最直接有效的方式，也是丰富他们未来可能的一种途径。</p>

                            <p>现在，我们将收到的明信片以电子地图的形式记录呈现，让更多人感受到善意的普遍存在。</p>

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
