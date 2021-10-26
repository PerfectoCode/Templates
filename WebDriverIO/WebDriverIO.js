var webdriverio = require('webdriverio');
var options = {
        desiredCapabilities: {
             platformName: 'ANDROID',                       
             browserName: 'chrome',                                             
             deviceName: 'yourDeviceID',
             securityToken: 'yourToken',
           
    },
    host: 'yourHost.perfectomobile.com',
    path: '/nexperience/perfectomobile/wd/hub',
port:80 
};
 
webdriverio
    .remote(options)
    .init()
    .url('http://www.google.com')
    .getTitle().then(function(title) {
        console.log('Title was: ' + title);
    })
    .end();
