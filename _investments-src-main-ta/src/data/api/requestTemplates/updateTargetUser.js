module.exports = {
    "full_name": "Company Admin",
    "job_title": "CA",
    "company": {
      "_id": "5c66ad55df0d252119d7982b",
      "explanation": {
        "value": 34980.75,
        "description": "sum of:",
        "details": [
          {
            "value": 33869.215,
            "description": "weight(company_name_term_lower:mercer in 2) [PerFieldSimilarity], result of:",
            "details": [
              {
                "value": 33869.215,
                "description": "score(doc=2,freq=1.0 = termFreq=1.0\n), product of:",
                "details": [
                  {
                    "value": 5000,
                    "description": "boost",
                    "details": [
                      
                    ]
                  },
                  {
                    "value": 6.773843,
                    "description": "idf, computed as log(1   (docCount - docFreq   0.5) / (docFreq   0.5)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "docFreq",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1311,
                        "description": "docCount",
                        "details": [
                          
                        ]
                      }
                    ]
                  },
                  {
                    "value": 1,
                    "description": "tfNorm, computed as (freq * (k1   1)) / (freq   k1) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "termFreq=1.0",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1.2,
                        "description": "parameter k1",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 0,
                        "description": "parameter b (norms omitted for field)",
                        "details": [
                          
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            "value": 1000,
            "description": "company_name_term_lower:mercer*, product of:",
            "details": [
              {
                "value": 1000,
                "description": "boost",
                "details": [
                  
                ]
              },
              {
                "value": 1,
                "description": "queryNorm",
                "details": [
                  
                ]
              }
            ]
          },
          {
            "value": 92.52839,
            "description": "weight(company_name:mercer in 2) [PerFieldSimilarity], result of:",
            "details": [
              {
                "value": 92.52839,
                "description": "score(doc=2,freq=1.0 = termFreq=1.0\n), product of:",
                "details": [
                  {
                    "value": 10,
                    "description": "boost",
                    "details": [
                      
                    ]
                  },
                  {
                    "value": 6.773843,
                    "description": "idf, computed as log(1   (docCount - docFreq   0.5) / (docFreq   0.5)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "docFreq",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1311,
                        "description": "docCount",
                        "details": [
                          
                        ]
                      }
                    ]
                  },
                  {
                    "value": 1.3659661,
                    "description": "tfNorm, computed as (freq * (k1   1)) / (freq   k1 * (1 - b   b * fieldLength / avgFieldLength)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "termFreq=1.0",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1.2,
                        "description": "parameter k1",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 0.75,
                        "description": "parameter b",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 2.897788,
                        "description": "avgFieldLength",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1,
                        "description": "fieldLength",
                        "details": [
                          
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            "value": 9.252839,
            "description": "weight(company_name:mercer in 2) [PerFieldSimilarity], result of:",
            "details": [
              {
                "value": 9.252839,
                "description": "score(doc=2,freq=1.0 = termFreq=1.0\n), product of:",
                "details": [
                  {
                    "value": 6.773843,
                    "description": "idf, computed as log(1   (docCount - docFreq   0.5) / (docFreq   0.5)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "docFreq",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1311,
                        "description": "docCount",
                        "details": [
                          
                        ]
                      }
                    ]
                  },
                  {
                    "value": 1.3659661,
                    "description": "tfNorm, computed as (freq * (k1   1)) / (freq   k1 * (1 - b   b * fieldLength / avgFieldLength)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "termFreq=1.0",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1.2,
                        "description": "parameter k1",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 0.75,
                        "description": "parameter b",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 2.897788,
                        "description": "avgFieldLength",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1,
                        "description": "fieldLength",
                        "details": [
                          
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            "value": 0.5,
            "description": "company_name:mercer*, product of:",
            "details": [
              {
                "value": 0.5,
                "description": "boost",
                "details": [
                  
                ]
              },
              {
                "value": 1,
                "description": "queryNorm",
                "details": [
                  
                ]
              }
            ]
          },
          {
            "value": 9.252839,
            "description": "weight(company_name:mercer in 2) [PerFieldSimilarity], result of:",
            "details": [
              {
                "value": 9.252839,
                "description": "score(doc=2,freq=1.0 = termFreq=1.0\n), product of:",
                "details": [
                  {
                    "value": 6.773843,
                    "description": "idf, computed as log(1   (docCount - docFreq   0.5) / (docFreq   0.5)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "docFreq",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1311,
                        "description": "docCount",
                        "details": [
                          
                        ]
                      }
                    ]
                  },
                  {
                    "value": 1.3659661,
                    "description": "tfNorm, computed as (freq * (k1   1)) / (freq   k1 * (1 - b   b * fieldLength / avgFieldLength)) from:",
                    "details": [
                      {
                        "value": 1,
                        "description": "termFreq=1.0",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1.2,
                        "description": "parameter k1",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 0.75,
                        "description": "parameter b",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 2.897788,
                        "description": "avgFieldLength",
                        "details": [
                          
                        ]
                      },
                      {
                        "value": 1,
                        "description": "fieldLength",
                        "details": [
                          
                        ]
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            "value": 0,
            "description": "match on required clause, product of:",
            "details": [
              {
                "value": 0,
                "description": "# clause",
                "details": [
                  
                ]
              },
              {
                "value": 1,
                "description": "company_status:active, product of:",
                "details": [
                  {
                    "value": 1,
                    "description": "boost",
                    "details": [
                      
                    ]
                  },
                  {
                    "value": 1,
                    "description": "queryNorm",
                    "details": [
                      
                    ]
                  }
                ]
              }
            ]
          }
        ]
      },
      "score": 34980.75,
      "sectors": [
        {
          "sector_name": "Outside Consultant/Institutional Advisor"
        }
      ],
      "num_of_emp_db": 3000,
      "company_domains": "mercer.com,pavilioncorp.com,ssgstl.com,halopowered.com,gmail.com,icy365.com",
      "company_name": "Mercer",
      "business_role": "Mercer Consultant",
      "description": "Explore Mercer's insights and thought leadership on global events, trends and policies affecting today's organizations.",
      "logo": {
        "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/uploads/202c5785f4794df6bed221bb04fe1615.png"
      },
      "location": {
        
      },
      "tags": [
        
      ]
    },
    "person_location": "San Francisco, United States",
    "preferred_region": null,
    "bio": "",
    "facebook": "",
    "twitter": "",
    "linkedin": "",
    "private": false,
    "user_roles": [
      {
        "_id": "5c7d4dc113280e04c296de69",
        "role_name": "content contributor",
        "createdAt": "2019-03-04T16:09:37.257Z",
        "updatedAt": "2019-03-04T16:09:37.280Z",
        "__v": 0,
        "id": "5c7d4dc113280e04c296de69"
      },
      {
        "_id": "5cddf70d03f0630038e25b41",
        "role_name": "company administrator",
        "createdAt": "2019-05-16T23:49:33.226Z",
        "__v": 0,
        "id": "5cddf70d03f0630038e25b41",
        "updatedAt": "2019-05-16T23:49:33.243Z"
      }
    ],
    "_id": "5d47d99407ea03001d997611"
  }