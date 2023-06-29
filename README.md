# Diploma_Zayats

**Testmonitor** https://qa_anastasiya_zayats.testmonitor.com/my-fir/issues

GIU TESTS:

| Test № |    Section    |            Checking                                                                                                  |    Test   | Match to the task     | 
|:-------|:--------------|:---------------------------------------------------------------------------------------------------------------------|:----------|:------------|
| L1     | Login         | Verify that user with valid credentials can login                                                                     | Positive |     | 
| L2     | Login         | Verify that user with invalid password can’t login                                                                    | Negative | тест на использование некорректных данных |
| P1     | Project       | Verify input ‘Name’ field [1-100] when creating project                                                               | Positive | тест на проверку поля для ввода на граничные значения, тест на ввод данных превышающих допустимые|               
| P1A    | Project       | Verify when required ‘Name’ field is empty, it’s not possible to create new project - the ‘Feature’ button is disabled| Negative | тест на проверку поля для ввода на граничные значения|
| P2     | Project       | Verify that it’s possible to create project with fill in all required data and verify that alert (about project was created) is displayed|  Positive | тест на создание сущности + тест на проверку всплывающего сообщения|
| P3     | Project       | Verify that it’s possible to archive a project                                                                         | Positive | тест на удаление сущности|
| P4     | Project       | Verify when clicking ‘Cancel’ button, when trying to archive a project, the project is not archived (Failed test for check screenshot allure) | Negative | тест воспроизводящий любой дефект|
| I1     | Issue         | Verify that when clicking on ‘Add issue’ button the dialogue window appears                                            | Positive | тест отображения диалогового окна|
| I2     | Issue         | Verify that it’s possible to add attachment to an issue                                                                | Positive | тест на загрузку файла|


API TESTS:

| HTTP-request |                        Endpoint                                     |            Description                     | Test № | Section     | Checking |
|:-------------|:--------------------------------------------------------------------|:-------------------------------------------|:-------|:------------|---------
| GET          | https://mydomain.testmonitor.com/api/v1/projects/{projectId}        | Retrieve a single project                  |P1      | Project     | Verify that project was retrieved successfully|
| POST         | https://mydomain.testmonitor.com/api/v1/project/{projectId}/archive | Archive a project                          | P2     | Project     | Verify that project was archived |
| GET          | https://mydomain.testmonitor.com/api/v1/issues/{issueId}            | Retrieve a single issue                    | I1     | Issue       | Verify that issue was retrieved successfully|               
| POST         | https://mydomain.testmonitor.com/api/v1/issues                      | Create an issue                            | I2     | Issue       | Verify that issue was created    
| GET          | https://mydomain.testmonitor.com/api/v1/requirements/{requirementId}| Retrieve a requirement using its identifier| R1     | Requirement | Verify that requirement was retrieved successfully|
