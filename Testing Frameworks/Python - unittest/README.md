## Python - unittest

[unittest](https://docs.python.org/2/library/unittest.html) is a testing framework for Python programing language.</br>
It's offer rich testing API in order to write your test fast, easily and most importent readable.

### Quick start: 
- Download the testing files [test.py](test.py) and [testConf.py](testConf,py) .
- Set your Perfecto Lab user,password and host name at [testConf.py](testConf,py): 
```python
#Set your Perfecto Lab security token and host
token = "MY_TOKEN"
host = "MY_HOST.perfectomobile.com"

#or use old school credentials instead of a security token (Not recommended)
user = "MY_USER"
password = "MY_PASS"    

```
- Set the desired device capabilities at the configuration file [testConf.py](testConf,py):
```python
#Set your test device capabilities
capabilities = {
    'platformName': 'Android',
    'platformVersion': '',
    'browserName': 'mobileOS',
    'model': ''
}
```
- Complite your test at the test class [test.py](test.py) :

```python
import unittest
from testConf import PerfectoTestBox

class testBox(PerfectoTestBox):

    #use self.driver as your testing webdriver
    #configuration and capabilities for this test class can be found at testConf.py
    def test_validate_title(self):
        #Navigate to google
        self.driver.get('https://www.google.com')

        #Write your test here...
```

- Run the test file as python program: 
```
python test.py
```