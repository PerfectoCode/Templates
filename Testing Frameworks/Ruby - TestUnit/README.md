## Ruby TestUnit

This template examine the using of Ruby testing framework named TestUnit.<br/>
TestUnit make your life easier by defining global test telmplates,such as before and after method for each of your tests.

### Quick start: 
- Set your Perfecto Lab username, password and host at [test_setup.rb](test_setup.rb) file:
```ruby 
#your host url
host = 'MY_HOST.perfectomobile.com'

#Your perfecto lab username and password
capabilities['user'] = 'MY_USER'
capabilities['password'] = 'MY_PASS' 
```

- Set your favorite device capabilities also at [test_setup.rb](test_setup.rb) file:
```ruby 
#device capabilities goes here:
capabilities = {
    :platformName => 'Android',
    :model => 'Galaxy S6', #Optional 
    :platformVersion => '', #Optional 
    :browserName => 'mobileOS', #Optional 
    :browserVersion => '', #Optional for web
    :deviceName => '' #Optional
}
```

- Write your test def the test template class MyTests which found at [test.rb](test.rb) file:<br/>
Remmber :exclamation: your test functions names must start with "tests_" 
```ruby 
def test_my_test
    #Here goes your test ...
end
```

- Execute the test class [test.rb](test.rb) using:
```bash
ruby test.rb
```
