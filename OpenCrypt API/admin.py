import requests
def main():
    prnt()
    print("Insert the URL: (http://website.website/dir)")
    url = input("> ")
    prnt()
    print("Insert admin key")
    token = input("> ")
    prnt()
    print("Insert new auth key")
    key = input("> ")
    requests.post(f'{url}/admin.php?ADMIN_TOKEN={token}?key={key}')
def prnt():
    var = """
    ###############################################
    #                                             #
    #         OPENCRYPT API ADMIN PORTAL          #
    #                                             #
    #              HELIXDEV 2021                  #
    #                                             #
    ###############################################
    """
    print("\n"*100)
    print(var)
if __name__ == '__main__':
    main()
