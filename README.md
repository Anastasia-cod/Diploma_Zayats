# Diploma_Zayats

**Testmonitor** https://qa_anastasiya_zayats.testmonitor.com/my-fir/issues

API TESTS:

| HTTP-request |                        Endpoint                                     |            Description                     | Checking |
|:-------------|:--------------------------------------------------------------------|:-------------------------------------------|---------
| GET          | https://mydomain.testmonitor.com/api/v1/projects/{projectId}        | Retrieve a single project                  |Verify that project was retrieved successfully|
| POST         | https://mydomain.testmonitor.com/api/v1/project/{projectId}/archive | Archive a project                          | Verify that project was archived |
| GET          | https://mydomain.testmonitor.com/api/v1/issues/{issueId}            | Retrieve a single issue                    | Verify that issue was retrieved successfully|               
| POST         | https://mydomain.testmonitor.com/api/v1/issues                      | Create an issue                            | Verify that issue was created    
| GET          | https://mydomain.testmonitor.com/api/v1/requirements/{requirementId}| Retrieve a requirement using its identifier| Verify that requirement was retrieved successfully|
