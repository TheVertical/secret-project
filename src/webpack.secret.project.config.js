const commonConfig = require('./webpack.common');

const path = require('path');

module.exports = (env) => {
    const config = commonConfig.getConfig(env);

    config.entry = {
        'lodash': 'lodash',
        'babel-polyfill': '@babel/polyfill',
        'react-vendor': 'react',
        'react-dom-vendor': 'react-dom',
        'redux-vendor': 'redux',
        'react-redux-vendor': 'react-redux',
        'secrert-project': './src/index.tsx'
    }
    config.output = {
        'path': path.resolve('../SecretProject.WebApi/Scripts/React', 'dist'),
        publicPath: 'auto',
        filename: '[name].bundle.js',
        chunkFilename: '[name].chunkhash.bundle.js',
    };

    return config;
}