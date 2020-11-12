<?xml version="1.0" encoding="UTF-8" ?>
<!-- fileversion=2.0 -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:include href="commonfile.xsl"/>
<xsl:template match="/">

<html>
<head>
<title>Local Query Result</title>
</head>
<body>
<div id="ead_dict_right" style="position:absolute;bottom:0;left:0;margin:0 10px;overflow:hidden;"></div>
<div id="actionTips" style="display:none">
  <div class="at-container">正在查询……</div>
</div>
<div id="zoomFont">
<div id="results">
<!-- 传统结果显示  如果存在则显示 -->
	<xsl:if test="yodaodict/custom-translation">
	<div id="yodao_anchor_basic" style="display:none"/>
	<xsl:for-each select="yodaodict/custom-translation">
	<xsl:if test="type[text()!='ee']" >
	<div class="trans-wrapper">
	    <!-- 输出关键词、音标、发音小喇叭 -->
		<h2>
		<xsl:call-template name="keyword_top_line">
				<xsl:with-param name="keyword" select="/yodaodict/return-phrase"/>
				<xsl:with-param name="phone" select="/yodaodict/phonetic-symbol"/>
				<xsl:with-param name="phonesup" select="phonesup"/>
				<xsl:with-param name="speech" select="/yodaodict/speech"/>
				<xsl:with-param name="field" select="field"/>
				<xsl:with-param name="origin" select="origin"/>
				<xsl:with-param name="showadd2wordbook">true</xsl:with-param>
		</xsl:call-template>
		</h2>
		 
		<xsl:call-template name="basic_tab">
			<xsl:with-param name="tab_type" select="type"/>
			<xsl:with-param name="tab_num" select="count(/yodaodict/custom-translation)"/>
			<xsl:with-param name="tab_name" select="name"/>
		</xsl:call-template>
    
		<!-- 显示英译中结果 -->
		<div  class="trans-container tab-content">
			
			<!-- 循环输出解释项 -->
			
			<ul>
			<xsl:for-each select="translation">
				<li><span class="pos"></span>
				<span class="def">
				<xsl:choose>
					<xsl:when test="../type[text()='ce']" >
            <span id ="translationContent">
              <xsl:element name="a">
                <xsl:attribute name="href">
                  app:ds:<xsl:value-of select="content" />
                </xsl:attribute>
                <xsl:attribute name="target">_self</xsl:attribute>
                <xsl:value-of select="content" />
              </xsl:element>
            </span>
					</xsl:when>
					<xsl:otherwise>
            <xsl:value-of select="content" />
					</xsl:otherwise>
				</xsl:choose>
				</span>
        </li>
			</xsl:for-each>
			</ul>
	
			<div class="showall">
		<!-- 语种切换 typo -->
			<xsl:call-template name="show_enter_for_more">
			<xsl:with-param name="cur_lang" select="/yodaodict/language"/>
			<xsl:with-param name="switch_lang" select="/yodaodict/lang"/>
			</xsl:call-template>
			</div>
			
		</div>
	</div>
	</xsl:if>
	</xsl:for-each>
	</xsl:if>
	
	<!-- 网络释义开始 -->
	<xsl:if test="not(yodaodict/custom-translation)">
	<xsl:if test="yodaodict/yodao-web-dict/web-translation">
	<div id="ecTrans" class="trans-wrapper">
	<!-- tab -->
    <xsl:call-template name="single_tab">
    	<xsl:with-param name="tab_title">网络释义</xsl:with-param>
    </xsl:call-template>
	
	<div id="ecTrans" class="trans-wrapper">
	<div class="trans-container">
	<ul>
	<xsl:for-each select="yodaodict/yodao-web-dict/web-translation">
	<li>
		<span class="pos"><xsl:value-of select="key"/> </span>
		<span class="def">：
			<!--输出所有的value, 并以 ‘；’ 隔开 -->
			<xsl:for-each select="trans">
			<xsl:value-of select="value"/>
				<xsl:if test="not(position() = count(../trans))">；</xsl:if>
			</xsl:for-each>
		</span> 
		<!--a class="sp add-fav" title="加入单词本" href="#"></a-->
	</li>
	</xsl:for-each>
	</ul>
	</div>
	</div>
	
	<table border="0" width="95%">
    <tr><td>
	<div class="showall"> 
		<!-- 语种切换 typo -->
	<xsl:call-template name="show_enter_for_more">
		<xsl:with-param name="cur_lang" select="/yodaodict/language"/>
		<xsl:with-param name="switch_lang" select="/yodaodict/lang"/>
	</xsl:call-template>
	</div>
    </td></tr></table>
  <!-- 显示/隐藏相关词组按钮 -->
  </div>
  	</xsl:if>
	</xsl:if>     <!-- 网络释义的结束 -->
	
	<xsl:if test="/yodaodict/ins_result-advt-show[text() = '1']"><div id="show_ins_adv" style="display:none"/></xsl:if>

	<div id="ead_dictr_ins" class="ead_line"></div>
	
	<!-- 如果没有上面的数据，那么显示本地词典的结果，否则，不显示-->
	<xsl:if test="not(yodaodict/custom-translation)">
	<xsl:if test="not(yodaodict/yodao-web-dict/web-translation)">
	<xsl:if test="yodaodict/local-dicts/dict/word[text() != '']">
	  <!-- show tab -->
		<div id="yodao_anchor_custom"/>
		
		<xsl:for-each select="yodaodict/local-dicts/dict">
		  <!-- disable none result display-->
		  <xsl:if test="word[text()!='']">			
				<!-- return word and phonetic-symbol -->
				<!--循环显示每部字典的内容-->
				<xsl:element name="div">
					<xsl:attribute name="id">yodao_anchor_custom<xsl:number value="position()"/></xsl:attribute>
					<xsl:attribute name="style">display:block</xsl:attribute>
				</xsl:element>
				<div class="trans-wrapper">
				<h2>				
					<xsl:call-template name="keyword_top_line">
						<xsl:with-param name="keyword" select="word" />
						<xsl:with-param name="phone" select="PhoneticSymbol"/>
						<xsl:with-param name="phonesup" select="phonesup"/>
						<xsl:with-param name="speech" select="nullpoint"/>
						<xsl:with-param name="field" select="field"/>
						<xsl:with-param name="origin" select="origin"/>
					</xsl:call-template>
				</h2>
                <xsl:call-template name="single_tab">
    				<xsl:with-param name="tab_title"><xsl:value-of select="name" disable-output-escaping="yes"/></xsl:with-param>
    			</xsl:call-template>
				<div class="trans-container">
				<div id="localdict">
					
					<!-- display the awful explain :( -->
					<xsl:for-each select="explains/explain">
						<xsl:if test="attr">
					   <div class="attr"><xsl:value-of select="attr" />
					   </div>
					   </xsl:if>
					   <xsl:for-each select="sub_explain">
					    <xsl:if test="meaning[text()!='']">
							<!--xsl:value-of select="position()"/-->
						   <div class="meaning">
						   	 <div><xsl:value-of select="meaning" /></div>
						   </div>
						 </xsl:if>
						</xsl:for-each>
					</xsl:for-each>
					<!-- display trans form of the word-->
					<xsl:if test="transforms">
					  <xsl:for-each select="transforms/transform">
	  						<xsl:value-of select="position()" /> 
							<div class="transform"><span>
								 <xsl:value-of select="type" disable-output-escaping="yes" />:
								 <xsl:value-of select="word" disable-output-escaping="yes" />;	
								</span>
							</div>
						</xsl:for-each>			
					</xsl:if>
					<!--display raw date,maybe should be hid -->
					<div class="raw"><xsl:value-of select="raw" disable-output-escaping="yes"/></div>
					</div>
				</div>
				</div>
				</xsl:if>
			</xsl:for-each>		

				
	</xsl:if>
	</xsl:if>
	</xsl:if>
    </div>
	</div>
   <OBJECT ID="flspins" WIDTH="0" HEIGHT="0" CLASSID="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" ></OBJECT>
</body>
</html>

</xsl:template>
</xsl:stylesheet>
