<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:include href="commonfile.xsl"/>
<xsl:template match="/">

<html>
<head>
<title>Local Query Result</title>

<!--link href="css/default.css" rel="stylesheet" type="text/css"/-->
<link href="css/new.css" rel="stylesheet" type="text/css"/>
<script language="javascript" src="js/default.js"></script>
</head>

<body>
<div id="actionTips" style="display:none">
	<div class="at-container">正在查询……</div>
</div>
<xsl:element name="div">
  <xsl:attribute name="class">
    <xsl:choose>
      <xsl:when test="yodaodict/lang[text()='eng'] and yodaodict/sentenceFrom[text()='net']">show_nav</xsl:when>
      <xsl:otherwise>dont_show_nav</xsl:otherwise>
    </xsl:choose>
  </xsl:attribute>  
	<div id="example_navigator">
		<h3 class="main-catalog ljblng">
			<span class="lable">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_双语');
				</xsl:attribute>
				双语例句
			</span>
		</h3>
		<ul class="sub-catalog group_1">
			<li class="ljblngcont_0">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_双语全部');
				</xsl:attribute>
				全部
			</li>
			<li class="ljblngcont_1">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_双语口语');
				</xsl:attribute>
				口语
			</li>
			<li class="ljblngcont_2">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_双语书面语');
				</xsl:attribute>
				书面语
			</li>
			<li class="ljblngcont_3">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_双语论文');
				</xsl:attribute>
				论文
			</li>
		</ul>
		<h3 class="main-catalog ljmdia">
			<span class="lable">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_原声');
				</xsl:attribute>
				原声例句
			</span>
		</h3>
		<ul class="sub-catalog group_2">
			<li class="ljmdia_0">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_原声全部');
				</xsl:attribute>
				全部
			</li>
			<li class="ljmdia_1">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_原声音频');
				</xsl:attribute>
				音频
			</li>
			<li class="ljmdia_2">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_原声视频');
				</xsl:attribute>
				视频
			</li>
		</ul>
		<h3 class="main-catalog ljauth">
			<span class="lable">
				<xsl:attribute name="onclick">
					javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '例句标签点击_权威');
				</xsl:attribute>
				权威例句
			</span>
		</h3>
	</div>
<div id="zoomFont">
	<div id="example_content" class="trans-container">

<xsl:call-template name="ead_block">
	<xsl:with-param name="ead_id">ead_dictrtop</xsl:with-param>
	<xsl:with-param name="style">ead_line_top</xsl:with-param>
</xsl:call-template>

	<!--查询词-->
	<xsl:variable name="query_word">
		<xsl:choose>
			<xsl:when test="yodaodict/sentences-result/trans/displayWord">
				<xsl:value-of select="yodaodict/sentences-result/trans/displayWord"/>
			</xsl:when>
			<xsl:when test="yodaodict/input">
				<xsl:value-of select="substring-after(yodaodict/input, 'lj:')"/>
			</xsl:when>
		</xsl:choose>
	</xsl:variable>
	<div id="queryword" style="display:none">
		<xsl:value-of select="$query_word"/>
	</div>

	<!--查询词的当前释义，可能为空-->
	<xsl:variable name="query_tran">
		<xsl:value-of select="yodaodict/sentences-result/trans/tran[@h='true']"/>
	</xsl:variable>
	<xsl:if test="$query_tran!=''">
		<div id="querytran" style="display:none">
			<xsl:value-of select="$query_tran"/>
		</div>
	</xsl:if>
	
	<!--当前查询的附加参数(标明分类)-->
	<xsl:variable name="ljtypes_params_str">
		<xsl:if test="yodaodict/ljtype">ljtype=<xsl:value-of select="yodaodict/ljtype"/></xsl:if>
		<xsl:if test="yodaodict/ljblngcont">&amp;ljblngcont=<xsl:value-of select="yodaodict/ljblngcont"/></xsl:if>
		<xsl:if test="yodaodict/ljmdia">&amp;ljmdia=<xsl:value-of select="yodaodict/ljmdia"/></xsl:if>
	</xsl:variable>
	<div id="param_ljtype" style="display:none"><xsl:value-of select="yodaodict/ljtype"/></div>
	<div id="param_ljblngcont" style="display:none"><xsl:value-of select="yodaodict/ljblngcont"/></div>
	<div id="param_ljmdia" style="display:none"><xsl:value-of select="yodaodict/ljmdia"/></div>

	<!-- 语种切换 typo -->
	<xsl:if test="/yodaodict/auto_switch_lang">
	<div class="tips-wrapper">
    <div class="tip">
			查词环境已更改为<strong>
			<xsl:call-template name="get_language_name">
			<xsl:with-param name="lang_type" select="/yodaodict/language"/>
			</xsl:call-template>
			</strong>。
	</div>
    </div>
	</xsl:if>
	
	<!--typo start-->
	<xsl:if test="yodaodict/typos">
		<div class="error-wrapper">
		<div class="error-typo">
			您是不是要找:<br/>
			<xsl:for-each select="yodaodict/typos/typo">
				<p class="wordGroup">
					<span class="contentTitle">
						<xsl:element name="a">
		   				<xsl:attribute name="href">app:lj:<xsl:value-of select="word" />?<xsl:value-of select="$ljtypes_params_str"/><xsl:if test="$query_tran!=''">&amp;ljtran=<xsl:value-of select ="$query_tran"/></xsl:if></xsl:attribute>
   						<xsl:attribute name="target">_self</xsl:attribute>
							<strong><xsl:value-of select="word" /></strong>
						</xsl:element>
					</span>
					<xsl:value-of select="trans"/>
				</p>
   		</xsl:for-each>
		</div>
		</div>
	</xsl:if>
	<!--typo end-->

	
	<!-- 例句开始 -->
		<!--双语例句-->
		<xsl:if test="yodaodict/ljtype[text()='blng']">
			<xsl:if test="yodaodict/sentences-result/trans/tran">
				<!--例句前面的解释-->
				<div class="content_title">
					<xsl:if test="$query_tran!=''">
						<xsl:element name="a">
							<xsl:attribute name="class">allExplanation</xsl:attribute>
							<xsl:attribute name="href">app:lj:<xsl:value-of select="$query_word"/>?<xsl:value-of select="$ljtypes_params_str"/></xsl:attribute>
							<xsl:attribute name="target">_self</xsl:attribute>
						</xsl:element>
					</xsl:if>

					<span class="tabLink">
						<span class="boldWord"><xsl:value-of select="$query_word"/>: </span>
						<xsl:for-each select="yodaodict/sentences-result/trans/tran">
							<xsl:choose>
								<xsl:when test="@h='true'">
									<a class="selected_link"><xsl:value-of select="."/></a>
								</xsl:when>
								<xsl:otherwise>
									<xsl:element name="a">
										<xsl:attribute name="onclick">
											javascript:ctlog("", '<xsl:call-template name="standard_return_phrase"/>', "0", "<xsl:value-of select="/yodaodict/keyfrom"/>", 1, 'CLICK', '点击释义_双语');
										</xsl:attribute>
										<xsl:attribute name="href">app:lj:<xsl:value-of select="$query_word"/>?<xsl:value-of select="$ljtypes_params_str"/>&amp;ljtran=<xsl:value-of select="." /></xsl:attribute>
										<xsl:attribute name="target">_self</xsl:attribute>
										<xsl:value-of select="." />
									</xsl:element>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:for-each>

					</span>
				</div>
			</xsl:if>

			<xsl:if test="yodaodict/sentences-result/example-sentences/sentence-pair">
				<xsl:apply-templates select="yodaodict/sentences-result/example-sentences">
					<xsl:with-param name="keyfrom">sentence</xsl:with-param>
				</xsl:apply-templates>
			</xsl:if>
			
			<!-- 没有结果的情况  -->
			<xsl:if test="not(yodaodict/sentences-result/example-sentences/sentence-pair)">
				<xsl:choose>
					<xsl:when test="yodaodict/lang[text()='eng'] and yodaodict/sentenceFrom[text()='net']">
						<div class="remind">
							<p>当前分类下找不到"<b><xsl:value-of select="$query_word"/><xsl:if test="$query_tran!=''">&#160;<xsl:value-of select ="$query_tran"/></xsl:if></b>"的例句</p>
							<xsl:if test="(yodaodict/ljblngcont!='0')">
								<p>查看双语例句分类下的<span class="tabLink">
									<xsl:element name="a">
										<xsl:attribute name="href">app:lj:<xsl:value-of select="$query_word"/>?ljtype=blng&amp;ljblngcont=0</xsl:attribute>
										<xsl:attribute name="target">_self</xsl:attribute>
										<xsl:attribute name="onclick"></xsl:attribute>全部例句</xsl:element></span></p>
							</xsl:if>
						</div>
						<xsl:if test="not(yodaodict/last_noresult_type[text()='mdia']) or not(yodaodict/last_noresult_type[text()='auth'])">
							<div class="example_see_also">
								<p>或者看看其他分类：</p>
								<xsl:if test="not(yodaodict/last_noresult_type[text()='mdia'])">
									<a class="info" id="see_originalSound" href="javascript:void(0)">
										<div class="originalSound">
                      <span class="icon"></span><span class="title">原声例句</span>
										</div>
										<p class="description">例句来自VOA、美剧等,您可以边看美剧边学地道的美语.</p>
									</a>
								</xsl:if>
								<xsl:if test="not(yodaodict/last_noresult_type[text()='auth'])">
									<a class="info" id="see_authority" href="javascript:void(0)">
										<div class="authority">
                      <span class="icon"></span><span class="title">权威例句</span>
										</div>
										<p class="description">例句来自权威英文网站、英文论文等,提供最专业的例句.</p>
									</a>
								</xsl:if>
							</div>
						</xsl:if>
					</xsl:when>
					<xsl:otherwise>
						<div class="remind">
							<p>找不到"<b><xsl:value-of select="yodaodict/input"/><xsl:if test="$query_tran!=''">&#160;<xsl:value-of select ="$query_tran"/></xsl:if></b>"的例句</p>
						</div>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:if>
		</xsl:if>
		<!--双语例句结束-->
		
			<!-- 处理本地结果的情况 -->
	<xsl:if test="yodaodict/sentenceFrom ='local'">
		<div class="trans-wrapper">
		 目前无法连接服务器，请检查您的网络连接或者查看<a>
		 		<xsl:attribute name="href">
					app:LJFAQ:/res/faq.html
				</xsl:attribute>
				<xsl:attribute name="target">_self</xsl:attribute>
				FAQ页面</a>。
		</div>
	</xsl:if>

		<!--权威例句-->
		<xsl:if test="yodaodict/ljtype[text()='auth']">
			<xsl:if test="yodaodict/sentences-result/auth-sents/sent">
				<xsl:apply-templates select="yodaodict/sentences-result/auth-sents">
					<xsl:with-param name="keyfrom">sentence</xsl:with-param>
				</xsl:apply-templates>
			</xsl:if>

			<!-- 没有结果的情况  -->
			<xsl:if test="not(yodaodict/sentences-result/auth-sents/sent)">
        <div class="remind">
          <p>
            当前分类下找不到"<b><xsl:value-of select="$query_word"/></b>"的例句
          </p>
        </div>
          <xsl:if test="not(yodaodict/last_noresult_type[text()='blng']) or not(yodaodict/last_noresult_type[text()='mdia'])">
						<div class="example_see_also">
              <p>或者看看其他分类：</p> 
							<xsl:if test="not(yodaodict/last_noresult_type[text()='blng'])">
								<a id="see_bilingual" class="info" href="javascript:void(0)">
									<div class="bilingual">
										<span class="icon"></span><span class="title">双语例句</span>
									</div>
									<p class="description">例句来自海量例句库，支持多维度筛选.</p>
								</a>
							</xsl:if>
							<xsl:if test="not(yodaodict/last_noresult_type[text()='mdia'])">
								<a class="info" id="see_originalSound" href="javascript:void(0)">
									<div class="originalSound">
                    <span class="icon"></span><span class="title">原声例句</span>
									</div>
									<p class="description">例句来自VOA、美剧等,您可以边看美剧边学地道的美语.</p>
								</a>
							</xsl:if>
						</div>
					</xsl:if>
			</xsl:if>
		</xsl:if>
		<!--权威例句结束-->
			
		<!--原声例句-->
		<xsl:if test="yodaodict/ljtype[text()='mdia']">
			<xsl:if test="yodaodict/sentences-result/media-sents/sent">
				<xsl:apply-templates select="yodaodict/sentences-result/media-sents">
					<xsl:with-param name="keyfrom">sentence</xsl:with-param>
				</xsl:apply-templates>
			</xsl:if>
			
			<!--没有结果的情况-->
			<xsl:if test="not(yodaodict/sentences-result/media-sents/sent)">
        <div class="remind">
          <p>
            当前分类下找不到"<b><xsl:value-of select="$query_word"/></b>"的例句</p>
					<xsl:if test="yodaodict/ljmdia!='0'">
						查看原声例句分类下的<span class="tabLink"><xsl:element name="a">
							<xsl:attribute name="href">app:lj:<xsl:value-of select="$query_word"/>?ljtype=mdia&amp;ljmdia=0</xsl:attribute>
							<xsl:attribute name="target">_self</xsl:attribute>
							<xsl:attribute name="onclick"></xsl:attribute>全部例句</xsl:element></span>
						
					</xsl:if>
          </div>  
					<xsl:if test="not(yodaodict/last_noresult_type[text()='blng']) or not(yodaodict/last_noresult_type[text()='auth'])">
						<div class="example_see_also">
              <p>或者看看其他分类：</p>
							<xsl:if test="not(yodaodict/last_noresult_type[text()='blng'])">
								<a id="see_bilingual" class="info" href="javascript:void(0)">
									<div class="bilingual">
										<!--TODO 图片及class修改-->
										<span class="icon"></span><span class="title">双语例句</span>
									</div>
									<p class="description">例句来自海量例句库，支持多维度筛选.</p>
								</a>
							</xsl:if>
							<xsl:if test="not(yodaodict/last_noresult_type[text()='auth'])">
								<a class="info" id="see_authority" href="javascript:void(0)">
									<div class="authority">
										<span class="icon"></span><span class="title">权威例句</span>
									</div>
									<p class="description">例句来自权威英文网站、英文论文等,提供最专业的例句.</p>
								</a>
							</xsl:if>
						</div>
					</xsl:if>
			</xsl:if>			
		</xsl:if>
		<!--原声例句结束-->
	</div>
	<!-- lj ads -->
	<xsl:call-template name="ead_block">
		<xsl:with-param name="ead_id">ead_dictr3</xsl:with-param>
		<xsl:with-param name="style">ead_line</xsl:with-param>
	</xsl:call-template>
</div>
	<!-- 例句结束 -->

    <xsl:if test="/yodaodict/ins_result-advt-show[text() = '1']"><div id="show_ins_adv" style="display:none"/></xsl:if>
 <OBJECT ID="flspins" WIDTH="0" HEIGHT="0" CLASSID="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" ></OBJECT>
</xsl:element>

<div id="example_content" class="trans-container">
<xsl:call-template name="ead_block">
	<xsl:with-param name="ead_id">ead_dictr_example_bottom</xsl:with-param>
	<xsl:with-param name="style">ead_line_example_bottom</xsl:with-param>
</xsl:call-template>
</div>

</body>
</html>
</xsl:template>                  
</xsl:stylesheet>