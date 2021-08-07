const webpack = require('webpack');

const appPath = __dirname;

exports.getConfig = (env) => {
    const devMode = !env.production;

    const plugins = [];

    if(devMode) {
        plugins.push(new webpack.SourceMapDevToolPlugin({
            filename: '[name].bundle.js.map',
            exclude: 'react-vendors'
        }));
    }

    return {
        
        mode: devMode ? 'development' : 'production',
        devtool: 'source-map',
        entry: {
            'react-vendors': [
                'jquery',
                'bootstrap',
                'react-bootstrap',
                'react',
                'react-dom',
                'react-router-dom',
                'react-redux',
                'redux',
            ]
        },
        watchOptions: {
            ignored: /node_modeules/
        },
        optimization: {
            minimize: devMode ? false : true,
            splitChunks: {
                chunks: 'async',
                minSize: 20000,
                minRemainingSize: 0,
                minChunks: 1,
                maxAsyncRequests: 30,
                maxInitialRequests: 30,
                enforceSizeThreshold: 50000,
                cacheGroups: {
                    vendor: {
                        chunks: 'initial',
                        name: 'react-vendors',
                        test: 'react-vendors',
                        enforce: true
                    }    
                }
            }
        },
        resolve: {
            extensions: ['.js', '.jsx', '.ts', '.tsx'],
            alias: {
                '@': appPath,
            }
        },
        module: {
            rules: [
                {
                    test: /\.ts(x?)$/,
                    exclude: /node_modules/,
                    use: [
                        {
                            loader: 'awesome-typescript-loader'
                        }
                    ]
                }
            ]
        },
        plugins: plugins
    }
}