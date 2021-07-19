const commonConfig = require('./webpack.common');

const path = require('path');

module.exports = (env) => {
    const config = commonConfig.getConfig(env);

    config.entry = {
        'babel-polyfill': '@babel/polyfill',
        'react-vendor': 'react',
        'redux-vendor': 'redux',
        'react-redux-vendor': 'react-redux',
        'react-dom-vendor': 'react-dom',
        'jquery-vendor': 'jquery',
        'secrert-project': './src/index.jsx'
    }
    config.output = {
        'path': path.resolve('../SecretProject.WebApi/Scripts/React', 'dist'),
        publicPath: '/',
        filename: '[name].bundle.js',
        chunkFilename: '[name].chunkhash.bundle.js',
    };

    return config;
}