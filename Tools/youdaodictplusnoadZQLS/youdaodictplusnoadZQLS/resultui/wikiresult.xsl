<?xml version="1.0" encoding="UTF-8" ?>
<!-- fileversion=2.0 -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:include href="commonfile.xsl"/>
<xsl:template match="/">

<html>
<head>
<title>wiki</title>
</head>

<body>
<div id="zoomFont">
<div id="results">
	<!-- 百科开始 -->
	
	<!-- 输出百科详细内容-->
  <div id="baike" class="trans-wrapper">
	<xsl:if test="yodaodict/BAIKE-DETAILS">
	<!--xsl:call-template name="baike_tab"/-->
	<!-- 先输出title -->
	
    <h2>
      <span class="subject">
        <xsl:value-of select="yodaodict/BAIKE-DETAILS/title"/>
      </span>
      <span class="via">
        百科内容来自于:
        <xsl:element name="a">
          <xsl:attribute name="href">
            <xsl:value-of select="yodaodict/BAIKE-DETAILS/source/url"/>
          </xsl:attribute>
          <xsl:attribute name="target">_blank</xsl:attribute>
          <xsl:attribute name="onclick">
            javascript:ctlog(this, "<xsl:value-of select="yodaodict/BAIKE-DETAILS/title"/>", 1, 1, 1, 'CLICK', 'hoodong_detail_logo_deskdict')
          </xsl:attribute>
          <xsl:element name="img">
            <xsl:attribute name="src">
              <xsl:value-of select="yodaodict/BAIKE-DETAILS/source/logo" />
            </xsl:attribute>
            <xsl:attribute name="border">0</xsl:attribute>
            <xsl:attribute name="width">56</xsl:attribute>
            <xsl:attribute name="align">absMiddle</xsl:attribute>
            <xsl:attribute name="alt">
              <xsl:value-of select="yodaodict/BAIKE-DETAILS/source/name" />
            </xsl:attribute>
          </xsl:element>
        </xsl:element>
      </span>
    </h2>
		<xsl:if test="yodaodict/BAIKE-DETAILS/headSection">
			<div class="description">
				<xsl:value-of select="yodaodict/BAIKE-DETAILS/headSection" disable-output-escaping="yes"/>
			</div>
		</xsl:if>	
	
	<xsl:for-each select="yodaodict/BAIKE-DETAILS/sections/section">
	

    <h3>

      <span class="sub-title">
        <xsl:value-of select="subtitle" disable-output-escaping="yes"/>
      </span>

      

    </h3>
    <!-- 输出详细内容 -->
    <xsl:element name="div">
      <xsl:attribute name="id">
        id<xsl:value-of select="subtitle"/>
      </xsl:attribute>
      <xsl:attribute name="class">trans-container</xsl:attribute>
      <div class="content">
        <xsl:value-of select="content" disable-output-escaping="yes"/>
      </div>
    </xsl:element>

  </xsl:for-each>

</xsl:if>

<!-- 输出更多相关词条(baike tab查询时)-->
<xsl:if test="yodaodict/BAIKE-SEARCH">
  <!--xsl:call-template name="baike_tab"/-->
  <h2>
     
      <span class="via">
        百科内容来自于:
        <xsl:element name="a">
          <xsl:attribute name="href">
            <xsl:value-of select="yodaodict/BAIKE-SEARCH/source/url"/>
          </xsl:attribute>
          <xsl:attribute name="target">_blank</xsl:attribute>
          <xsl:attribute name="title">
            <xsl:value-of select="yodaodict/BAIKE-SEARCH/source/name"/>
          </xsl:attribute>
          <xsl:attribute name="onclick">
            javascript:ctlog(this, "<xsl:call-template name="standard_return_phrase" />", 1, 1, 1, 'CLICK', 'hoodong_search_deskdict')
          </xsl:attribute>
          <xsl:value-of select="yodaodict/BAIKE-SEARCH/source/name"/>
        </xsl:element>
      </span>
    </h2>
    <div class="trans-container suggests">
      <xsl:for-each select="yodaodict/BAIKE-SEARCH/items/item">
        <xsl:call-template name="baike_item">
          <xsl:with-param name="key" select="title"/>
          <xsl:with-param name="summary" select="summary"/>
          <xsl:with-param name="image" select="image"/>
          <xsl:with-param name="show_external">true</xsl:with-param>
          <xsl:with-param name="show_more">false</xsl:with-param>
          <xsl:with-param name="ctype_title">related_wiki_summary_title_deskdict</xsl:with-param>
          <xsl:with-param name="ctype_external">related_wiki_summary_external_deskdict</xsl:with-param>
        </xsl:call-template>
   
      </xsl:for-each>
    </div>
	</xsl:if>
</div>
	<!-- 百科结束 -->

	<!-- 没有结果的情况  -->
	<xsl:if test="not(yodaodict/baike)">
		<xsl:if test="not(yodaodict/BAIKE-SEARCH)">
			<xsl:if test="not(yodaodict/BAIKE-DETAILS)">

		<!--typo start-->
		<xsl:if test="yodaodict/typos">
      <div class="error-wrapper">
        <div class="error-typo">
          您是不是要找: <br/>
          <xsl:for-each select="yodaodict/typos/typo">
            <p class="wordGroup">
              <span class="contentTitle">

                <xsl:element name="a">
                  <xsl:attribute name="href">
                    app:bk:<xsl:value-of select="./word" />
                  </xsl:attribute>
                  <xsl:attribute name="target">_self</xsl:attribute>
                  <strong>
                    <xsl:value-of select="./word" />
                  </strong>
                </xsl:element>
              </span>
              <xsl:value-of select="./trans" />
            </p>
          </xsl:for-each>
        </div>
      </div>
<br/>
		</xsl:if>
		<!--typo end-->

		<div class ="trans-wrapper" id="error">
		  <br />
			抱歉，没有找到与您查询的"<b>
			  <xsl:call-template   name="SubStringFun">   
			  	<xsl:with-param   name="input"   select="/yodaodict/input"   />   
				<xsl:with-param   name="from"   select="'bk:'" />   
			    <xsl:with-param   name="to"   select="''"  />
			  </xsl:call-template>
			</b>"相关的百科结果。
			<br /><br />
			<br />
			<li>请查看输入的字词是否有错误</li>
			<li>请在网页搜索中搜索"<xsl:element name="a">
					<xsl:attribute name="href">http://www.youdao.com/search?
						keyfrom=<xsl:value-of select="yodaodict/keyfrom" />.noresult&amp;
						q=<xsl:call-template   name="SubStringFun">   
						<xsl:with-param   name="input"   select="/yodaodict/input"   />   
						<xsl:with-param   name="from"   select="'bk:'" />   
						<xsl:with-param   name="to"   select="''"  />
					  </xsl:call-template>
					</xsl:attribute>
					<xsl:attribute name="target">_blank</xsl:attribute>
					  <xsl:call-template   name="SubStringFun">   
						<xsl:with-param   name="input"   select="/yodaodict/input"   />   
						<xsl:with-param   name="from"   select="'bk:'" />   
						<xsl:with-param   name="to"   select="''"  />
					  </xsl:call-template>
				</xsl:element>"
			</li>
			<li>请阅读<xsl:element name="a">
				<xsl:attribute name="href">
					<xsl:value-of select="/yodaodict/helpurl" disable-output-escaping="yes"/>
				</xsl:attribute>
				<xsl:attribute name="target">_blank</xsl:attribute>帮助</xsl:element>
			</li>			
		</div>	
          </xsl:if>
		</xsl:if>
	</xsl:if>
    </div>
	</div>

 <div id="baike" class="trans-wrapper">
	<xsl:call-template name="ead_block">
		<xsl:with-param name="ead_id">ead_dictr_wiki_bottom</xsl:with-param>
		<xsl:with-param name="style">ead_line_wiki_bottom</xsl:with-param>
	</xsl:call-template>
</div>


</body>
</html>
</xsl:template>                  
</xsl:stylesheet>