{
  "targets": [
    {
      "target_name": "addon",
      "sources": [ "src/hello.cc" ],
      "include_dirs": [
      "<!(node -e \"require('nan')\")"
      ]
    }
  ]
}