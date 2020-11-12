<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:include href="commonfile.xsl"/>
<xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes'/>

<xsl:template match="/">
<html>
<head>

</head>
<body>

<xsl:choose>
	<xsl:when test="/yodaodict/fanyi-result">
	<!--如果是翻译结果-->
		<div id="dict_result">
			<h1 class="item-bar">
			<div class="background"></div>
			翻译<a rel="#trans" class="toggle toggleOpen"></a>
			</h1>
		
		<div class="item-content">
			<div class="toggle-js" id="trans">
				<div class="tran-result">
					<xsl:value-of select="yodaodict/fanyi-result/tran"/>
				</div>
				<div class="options">
					<span class="go-trans"><a href="app:trans:more" class="link">进入翻译页面»</a></span>
					语言
					<div class="language-type">
						<span class="select"><a href="app:trans:AUTO">自动检测</a></span>
					</div>

					<ul class="types select">
						<li class="AUTO"><a class="type" href="app:trans:AUTO">自动检测</a></li>
						<li class="ZH_CN2EN"><a class="type" href="app:trans:ZH_CN2EN">汉->英</a></li>
						<li class="ZH_CN2JA"><a class="type" href="app:trans:ZH_CN2JA">汉->日</a></li>
						<li class="ZH_CN2KR"><a class="type" href="app:trans:ZH_CN2KR">汉->韩</a></li>
						<li class="ZH_CN2FR"><a class="type" href="app:trans:ZH_CN2FR">汉->法</a></li>
						<li class="EN2ZH_CN"><a class="type" href="app:trans:EN2ZH_CN">英->汉</a></li>
						<li class="JA2ZH_CN"><a class="type" href="app:trans:JA2ZH_CN">日->汉</a></li>
						<li class="KR2ZH_CN"><a class="type" href="app:trans:KR2ZH_CN">韩->汉</a></li>
						<li class="FR2ZH_CN"><a class="type" href="app:trans:FR2ZH_CN">法->汉</a></li>
					</ul>
				</div>
			</div>
		</div>
		</div>
	</xsl:when>
	
	<xsl:otherwise>
		<!--词典结果-->
		<div id="dict_result">
			<h1 class="item-bar">
				<div class="background"></div>
				词典
				<a rel="#dict" class="toggle toggleOpen"></a>
			</h1>
	
			<div class="item-content">
				<xsl:choose>
					<xsl:when test="/yodaodict/lang">
						<div class="toggle-js" id="dict">
							<h2>
								<xsl:value-of select="yodaodict/return-phrase"/>
								<span class="phonetic">
									<xsl:if test="yodaodict/phonetic-symbol[text() != '']">
										[<xsl:value-of select="yodaodict/phonetic-symbol"/>]
									</xsl:if>
								</span>
								<!--判断是否需要发音图标-->
								<xsl:apply-templates select="yodaodict/dictcn-speach">
									<xsl:with-param name="objId"/>
									<xsl:with-param name="keyfrom">stroke</xsl:with-param>
								</xsl:apply-templates>
								<!--加入单词本-->
								<xsl:element name="a">
								<xsl:attribute name="class">sp add-fav</xsl:attribute>
								<xsl:attribute name="title">加入单词本</xsl:attribute>
								<xsl:attribute name="id">addFav</xsl:attribute>
								<xsl:attribute name="ref"><xsl:value-of select="yodaodict/return-phrase"/></xsl:attribute>
								<xsl:attribute name="href">app:addword:<xsl:value-of select="yodaodict/return-phrase"/></xsl:attribute>
								<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.stroke' , 1, 'CLICK',  'WordBook');</xsl:attribute>
								</xsl:element>
								<!--详细-->
								<a href="app:detail" class="link">详细»</a>
							</h2>
							
							<xsl:for-each select="yodaodict/custom-translation/translation/content">
							<p>
								<xsl:value-of select="."/>
							</p>
							</xsl:for-each>
							
							<!--判断是否应该出现网络释义-->
							<xsl:if test="yodaodict/yodao-web-dict">
								<h3 class="sub-item">网络释义<span>┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈</span></h3>
								<p>
									<xsl:for-each select="yodaodict/yodao-web-dict/web-translation[position()=1]">
										<p>
											<xsl:for-each select="./trans/value">
												<span class="web-item">
													<xsl:value-of select="."/>
												</span>
												<xsl:if test="position()!=last()">
													<span class="split"></span><!--输出一个间隔符-->
												</xsl:if>
											</xsl:for-each>
										</p>
									</xsl:for-each>
								</p>
							</xsl:if>
						</div>
					</xsl:when>
					<xsl:otherwise>
						<div class="toggle-js" id="dict">
							<h2><xsl:value-of select="yodaodict/return-phrase"/></h2>
							<p>抱歉，您选中的词在词典里没有结果。请查看搜索结果。</p>
						</div>	
					</xsl:otherwise>
				</xsl:choose>
			</div>
		</div>

	</xsl:otherwise>
</xsl:choose>
	
</body>
</html>

</xsl:template>
</xsl:stylesheet>


