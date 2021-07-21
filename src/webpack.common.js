const webpack = require('webpack');
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');

const appPath = __dirname;

exports.getConfig = (env) => {
    const devMode = !env.production;

    const plugins = [];

    if(devMode) {
        plugins.push(new webpack.SourceMapDevToolPlugin({
            filename: '[name].bundle,js.map',
            exclude: ['react-vendors']
        }));
    }

    return {
        
        mode: devMode ? 'development' : 'production',
        devtool: 'source-map',
        entry: {
            'react-vendors': [
                'jquery',
                'react',
                'react-dom',
                'react-redux',
                'redux',
            ]
        },
        externals: {
            'react': 'React',
            'react-dom': 'ReactDOM'
        },
        plugins: [
            new webpack.ProvidePlugin({
              "React": "react",
            }),
          ],
        watchOptions: {
            ignored: /node_modeules/
        },
        optimization: {
            minimizer: [
                new UglifyJSPlugin({
                    sourceMap: true,
                    uglifyOptions: {
                        compress: {
                            inline: true
                        }
                    }
                })
            ],
            splitChunks: {
                cacheGroups: {
                    vendor: {
                        chunks: 'initial',
                        name: 'react-vendors',
                        test: 'react-vendors',
                        enforce: true
                    }
                }
            },

        },
        resolve: {
            extensions: ['.js', '.jsx', '.ts', '.tsx'],
            modules: ['node_modules']
        },
        module: {
            rules: [
                {
                    test: /\.ts(x?)$/,
                    exclude: /(node_modules|bower_components)/,
                    use: [
                        {
                            loader: 'awesome-typescript-loader'
                        }
                    ]
                },
                {
                    test: /\.m?js$/,
                    exclude: /(node_modules|bower_components)/,
                    use: [
                        {
                      loader: "source-map-loader",
                    }
                    ]
                },
                {
                    test: /\.jsx$/,
                    exclude: /node_modules/,
                    use: [{
                      loader: "babel-loader",
                      options: {
                        presets: ['@babel/preset-react', '@babel/preset-env'],
                        rootMode: "upward"
                      }
                    }]
                },
                {
                    test: /\.js/,
                    exclude: /node_modules/,
                    use: [{
                        loader: "babel-loader",
                        options: {
                            presets: ['@babel/preset-react', '@babel/preset-env'],
                            rootMode: "upward"
                        }
                    }]
                },
            ]
        }
    }
}